# 層構造の原則

## 基本構造

あらゆるシステムに適用できる汎用の第一階層。不要な層は省略する。

```
src/
├── Admin/          — アプリケーションの起動・終了管理
├── Application/    — ユースケースのオーケストレーション
├── Domain/         — ビジネスロジック
├── Infrastructure/ — DB・ハードウェア・設定・外部サービス
├── Presentation/   — 外向きの窓口
│   ├── UI/         — ユーザーインターフェース
│   └── Facade/     — 外部通信インターフェース
└── Safety/         — 安全監視（機能安全が必要な場合のみ）
```

## 依存の方向

Domainを中心とし、すべての矢印がDomainへ向かう。DomainはいかなるLayerにも依存しない。

```
Admin    Safety    Presentation
              ↓
          Application
         ↙          ↘
   Infrastructure    Domain
```

| 層 | 依存先 |
|---|---|
| Admin | Application |
| Application | Domain |
| Infrastructure | Domain（インターフェースの実装） |
| Presentation | Application |
| Safety | Infrastructure（Applicationをバイパス） |

## 各層の責務

| 層 | 責務 |
|---|---|
| Admin | アプリケーションのライフタイム管理のみ |
| Application | Domain・Infrastructure・Presentationの呼び出しと組み合わせ。ビジネスロジックを持たない |
| Domain | ビジネスルール。Source / Transform / Sinkで構成 |
| Infrastructure | 永続化・ハードウェア・設定値。すべて外部データの読み書き |
| Presentation | システムの外向きの窓口。ビジネスロジックを持たない |
| Safety | 通常パスから独立した安全監視。Applicationを経由しない |

## Safety層の独立性

Safety層はApplicationを経由せず、Infrastructureへ直通する。

> 安全機能は他のコードから干渉を受けてはならない（ISO 26262 / IEC 61508）

Adminが起動処理で詰まっていても、Safetyは確実に動作する。

## Presentation層と状態管理

PresentationはApplicationの状態を映すだけ。画面遷移の判断もPresentation層が自律的に行う。

```
Presentation → Application（ユーザー操作を通知）
Application  → Presentation（状態を返す）
Presentation → 状態から自律的に画面を決定・遷移
```

ApplicationはPresentation（画面）を知らない。状態を返すだけ。
Presentationは状態から画面への変換責任を持つ。

これにより依存は一方向のままになる。「画面」と「状態」の二重管理も発生しない。

## Domainの値表現

Domainの値は抽象的な識別子（数値・enum等）で定義する。表示用文字列はDomainに属さない。

| Domain ○ | Domain ✗ |
|----------|----------|
| `enum Hand { Rock = 0, Scissors = 1, Paper = 2 }` | `type Hand = 'グー' \| 'チョキ' \| 'パー'` |

表示文字列がDomainにあると、表示の変更（多言語対応・表示形式変更）がDomainに波及する。ビジネスルールの判断（勝敗等）は値の数学的性質（循環・大小・等値）で表現する。

## 値と判断の分離

Value Objectは値の定義だけを持つ。判断ロジックは判断だけを行う別モジュールに分離する。

| ✗ 値に判断を持たせる | ○ 判断を分離する |
|-------------------|----------------|
| `Hand.beats(other)` | `judgeWinner(player, system)` |

値が判断を持つと、値の定義と判断の責務が混在する。

## Presentation層の表示制約

Presentation層のView（UI）は、受け取った表示用データをそのまま描画する。変換テーブル・マッピング・フォーマット処理はViewに属さない。

内部表現（数値・enum）から表示用文字列への変換は、Viewに到達する前に完了する。Viewに届くデータは表示可能な形式（文字列等）でなければならない。

## 設定値の扱い

設定値はInfrastructureが担う。DBの値と責務が同一（外部に永続化されたデータの読み書き）であるため。

Domainに設定インターフェースを定義し、Infrastructureが実装する。
