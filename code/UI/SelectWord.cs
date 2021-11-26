﻿using Sandbox.UI;
using Sandbox;
using Sandbox.UI.Construct;
using static Sketch.Game;

namespace Sketch
{
	public partial class SelectWord : Panel
	{
		public Panel Container;
		public string[] Pool;
		private RealTimeUntil stateEnd;

		public SelectWord()
		{
			StyleSheet.Load( "/ui/SelectWord.scss" );

			Add.Label( "SELECT A WORD", "title" );
			Container = Add.Panel( "container" );
		}

		public override void Tick()
		{
			if ( Current == null ) return;

			if(stateEnd < 0)
			{
				RemoveClass( "open" );
				AddClass( "closed" );
			}

		}

		public void DisplayWordPool(int time)
		{
			Container.DeleteChildren( true );
			foreach (var w in Pool)
			{
				Container.Add.Button( w, "wordbutton", () => SelectedWord(w));
			}

			AddClass( "open" );
			RemoveClass( "closed" );

			stateEnd = time;
		}

		public void SelectedWord(string word)
		{
			Game.SelectWord( word );
			stateEnd = -1;
		}
	}
}