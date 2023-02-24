using Extensions;
using System.Linq;

namespace MyLinqTests
{
	public class UnitTests
	{
		[Fact]
		public void MyWhereTest()
		{
			int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			Func<int, bool> predicate = x => x > 5;

			var expected = source.Where(predicate);
			var actual = source.MyWhere(predicate);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
		[InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
		[InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
		[InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
		public void MyWhereTest2(int[] source)
		{
			Func<int, bool> resultPredicate = x => x > 5;

			var resultExpected = source.Where(resultPredicate);
			var resultActual = source.MyWhere(resultPredicate);

			Assert.Equal(resultExpected, resultActual);
		}

		//TODO: Write such test cases for each method.
	}
}