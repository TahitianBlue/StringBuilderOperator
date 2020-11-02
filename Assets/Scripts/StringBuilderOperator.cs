
// StringBuilderOperator
// StringBuilder wrapper class. Execute Append () with operator +.
// -　extension cannot add operator (C # language specification)
// -　StringBuilder class is sealed and cannot be inherited
// -　There is no choice but to wrap it in another class. That is the StringBuilderOperator class
//
// Keep a StringBuilder instance inside this class and share it throughout your program code
//
// How to use
// Declare the following at the beginning of the file
//  using SBO = StringBuilderOperator.StringBuilderOperator;
//
// String concatenation
//  string s = SBO.i + "aaa" + 20 + "bbbb";
//
// For multiple statements (loop, etc.)
//  SBO s = SBO.i; // Hold string as SBO type
//  for (int i = 0; i <100; i ++) s + = someString; // Concatenate with SBO type
// Note that if you write s = SBO.i + s + someString; in string type, SBO.ToString () will be executed for each loop and it will be slow.
//
// Only available in the main thread. If called, it will give a LogError.


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
//	using SBO = StringBuilderOperator.StringBuilderOperator;
//
// 連結
//	string s = SBO.i + "aaa" + 20 + "bbbb";
//
// 複数ステートメントで連結する場合（ループなど）
//	SBO s = SBO.i; // SBO型で文字列を保持
//	for( int i=0 ; i<100 ; i++ ) s += someString; // SBO型で連結すること
// string型で s = SBO.i + s + someString; ではループ毎にSBO.ToString()が実行されて遅くなるので注意
//
// メインスレッド以外では利用できません。LogErrorを出します。

using System.Threading;
using System.Text;

namespace StringBuilderOperator
{
	/// <summary>
	/// StringBuilderOperator optimizes string concat operation simply.
	/// string s = SBO.i + "aaa" + 20 + "bbbb";
	/// </summary>
	public class StringBuilderOperator
	{
		private static StringBuilderOperator instance;
		private static int mainThreadId = Thread.CurrentThread.ManagedThreadId;

		public StringBuilder sb { get; private set; }
		public const int initialCapacity = 1024;

		// constructor
		static StringBuilderOperator()
		{
			instance = new StringBuilderOperator();
		}
		private StringBuilderOperator()
		{
			sb = new StringBuilder( initialCapacity );
		}

		// instance i
		public static StringBuilderOperator i
		{
			get {
				if( mainThreadId != Thread.CurrentThread.ManagedThreadId )
				{
					UnityEngine.Debug.LogError( "Called in another thread." );
					return null;
				}
				instance.sb.Length = 0;
				return instance;
			}
		}


		public override string ToString()
		{
			return sb.ToString();
		}
		public static implicit operator string( StringBuilderOperator t )
		{
			return t.ToString();
		}

		#region ADD_OPERATOR
		public static StringBuilderOperator operator +( StringBuilderOperator t, bool v )
		{
			t.sb.Append( v );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, int v )
		{
			t.sb.Append( v );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, short v )
		{
			t.sb.Append( v );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, byte v )
		{
			t.sb.Append( v );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, float v )
		{
			t.sb.Append( v );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, char c )
		{
			t.sb.Append( c );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, char[] c )
		{
			t.sb.Append( c );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, string s )
		{
			t.sb.Append( s );
			return t;
		}
		public static StringBuilderOperator operator +( StringBuilderOperator t, StringBuilder sb )
		{
			t.sb.Append( sb );
			return t;
		}
		#endregion ADD_OPERATOR
	}
}
