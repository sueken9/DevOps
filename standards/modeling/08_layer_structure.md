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

## 設定値の扱い

設定値はInfrastructureが担う。DBの値と責務が同一（外部に永続化されたデータの読み書き）であるため。

Domainに設定インターフェースを定義し、Infrastructureが実装する。
