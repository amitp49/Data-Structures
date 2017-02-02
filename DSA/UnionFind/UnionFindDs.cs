// /Users/amitp/Documents/dsa/DSA/UnionFind/MyClass.cs
// amitp
// (c) Amit Patel
// 03-01-2017
using System;
using System.ComponentModel;
namespace UnionFind
{
	
	public class UnionFindDs
	{
		private int size;
		private Group[] group;

		public UnionFindDs(int size)
		{
			this.size = size;
			this.group = new Group[this.size];
			for (int i = 0; i < this.size; i++)
			{
				this.group[i] = new Group(i,1); // leader/parent itself, and size equals 1
			}
		}

		public void Union(int a, int b)
		{
			int groupLeaderForTeamA = Find(a);
			int groupLeaderForTeamB = Find(b);

			int teamASize = this.group[groupLeaderForTeamA].Size;
			int teamBSize = this.group[groupLeaderForTeamB].Size;

			if (teamBSize > teamASize) // merge smaller into bigger
			{
				this.group[groupLeaderForTeamA].Parent = this.group[groupLeaderForTeamB].Parent;
				this.group[groupLeaderForTeamB].Size += this.group[groupLeaderForTeamA].Size;
			}
			else
			{
				this.group[groupLeaderForTeamB].Parent = this.group[groupLeaderForTeamA].Parent;
				this.group[groupLeaderForTeamA].Size += this.group[groupLeaderForTeamB].Size;
			}
		}

		public int Find(int a)
		{
			int groupLeader = this.group[a].Parent;
			if (groupLeader == a) // memeber is along in group. member itself is leader
			{
				return groupLeader;
			}
			this.group[a].Parent = Find(groupLeader); // path compression
			return groupLeader;
		}
	}
}

