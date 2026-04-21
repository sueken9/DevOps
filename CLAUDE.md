# CLAUDE.md

## principlesドキュメントの書き方

- **WHATで書く。HOWで書かない。**
  - ルール・定義・事実を記述する
  - 手順・操作・やり方は書かない

## 開発の進め方

構造化設計を基本とし、以下のフローで進める。
詳細は `principles/modeling/development_flow.md` を参照。

```
要件定義 → コンテキストダイアグラム → データ辞書
→ 整合性確認 → イベントリスト → 各ドキュメント更新 → DFD → ...
```

## ドキュメント間の整合性

コンテキストダイアグラム・データ辞書・イベントリストは常に整合していなければならない。
一つが変わったら、他のすべてを確認・更新する。

## principlesの場所

`principles/modeling/` 配下に設計原則をカテゴリ別に蓄積する。
- `context_diagram.md` — コンテキストダイアグラムの原則
- `data_dictionary.md` — データ辞書の原則
- `event_list.md` — イベントリストの原則
- `development_flow.md` — 開発フローの原則
