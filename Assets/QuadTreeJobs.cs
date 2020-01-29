using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace marijnz.NativeQuadTree
{
	/// <summary>
	/// Examples on jobs for the NativeQuadTree
	/// </summary>
	public static class QuadTreeJobs
	{
		/// <summary>
		/// Bulk insert many items into the tree
		/// </summary>
		[BurstCompile]
		public struct AddBulkJob : IJob
		{
			[ReadOnly]
			public NativeArray<QuadElement> Elements;

			public NativeQuadTree QuadTree;

			public void Execute()
			{
				QuadTree.BulkInsert(Elements);
			}
		}

		/// <summary>
		/// Example on how to do a range query, it's better to write your own and do many queries in a batch
		/// </summary>
		[BurstCompile]
		public struct RangeQueryJob : IJob
		{
			[ReadOnly]
			public AABB2D Bounds;

			[ReadOnly]
			public NativeQuadTree QuadTree;

			[WriteOnly]
			public NativeList<QuadElement> Results;

			public void Execute()
			{
				QuadTree.RangeQuery(Bounds, Results);
			}
		}
	}
}