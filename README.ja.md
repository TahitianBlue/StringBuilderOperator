// StringBuilderOperator
// StringBuilderのラッパークラス　オペレーター＋演算子でAppend()ができるようにするもの
// - extension では operator を追加できない（C#言語仕様）
// - StringBuilderクラスはsealedなので継承できない
// - 別クラスでラップするしかない それがStringBuilderOperatorクラス
//
// 内部でStringBuilderインスタンスを保持してプログラム全体で共有します
//
// 使い方
// ファイル先頭に以下を宣言
//    using SBO = StringBuilderOperator.StringBuilderOperator;
//
// 連結
//    string s = SBO.i + "aaa" + 20 + "bbbb";
//
// 複数ステートメントで連結する場合（ループなど）
//    SBO s = SBO.i; // SBO型で文字列を保持
//    for( int i=0 ; i<100 ; i++ ) s += someString; // SBO型で連結すること
// string型で s = SBO.i + s + someString; ではループ毎にSBO.ToString()が実行されて遅くなるので注意
//
// メインスレッド以外では利用できません。LogErrorを出します。
