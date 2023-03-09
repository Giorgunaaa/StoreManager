using Extensions;
using System.Linq;

namespace MyLinqTests
{
    public class UnitTests
    {
        //[Fact]
        //public void MyWhereTest()
        //{
        //	int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //	Func<int, bool> predicate = x => x > 5;

        //	var expected = source.Where(predicate);
        //	var actual = source.MyWhere(predicate);

        //	Assert.Equal(expected, actual);
        //}

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyWhereTest(int[] source)
        {
            Func<int, bool> resultPredicate = x => x > 5;

            var resultExpected = source.Where(resultPredicate);
            var resultActual = source.MyWhere(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        //TODO: Write such test cases for each method.

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 5, 1, 2, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 3, 4, 5, 7, 16, 7, 34, 65, 10, 3 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 }, new[] { 1, 2, 2, 2, 2, 2, 2, 22, -10 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 }, new[] { 1, 16, 1, 1, 2, 67, 3, -1, 0 })]
        public void MyUnionTest(int[] first, int[] second)
        {
            var resultExpected = first.Union(second);
            var resultActual = first.MyUnion(second);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 5, 1, 2, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 3, 4, 5, 7, 16, 7, 34, 65, 10, 3 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 }, new[] { 1, 2, 2, 2, 2, 2, 2, 22, -10 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 }, new[] { 1, 16, 1, 1, 2, 67, 3, -1, 0 })]
        public void MyConcatTest(int[] first, int[] second)
        {
            var resultExpected = first.Concat(second);
            var resultActual = first.MyConcat(second);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 5, 1, 2, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 3, 4, 5, 7, 16, 7, 34, 65, 10, 3 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 }, new[] { 1, 2, 2, 2, 2, 2, 2, 22, -10 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 }, new[] { 1, 16, 1, 1, 2, 67, 3, -1, 0 })]
        public void MyExceptTest(int[] first, int[] second)
        {
            var resultExpected = first.Except(second);
            var resultActual = first.MyExcept(second);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 5, 1, 2, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 3, 4, 5, 7, 16, 7, 34, 65, 10, 3 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 }, new[] { 1, 2, 2, 2, 2, 2, 2, 22, -10 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 }, new[] { 1, 16, 1, 1, 2, 67, 3, -1, 0 })]
        public void MyIntersect(int[] first, int[] second)
        {
            var resultExpected = first.Intersect(second);
            var resultActual = first.MyIntersect(second);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyDistinct(int[] source)
        {
            var resultExpected = source.Distinct();
            var resultActual = source.MyDistinct();

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyFirst(int[] source)
        {
            var resultExpected = source.First();
            var resultActual = source.MyFirst();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.First(resultPredicate);
            resultActual = source.MyFirst(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyFirstOrDefaultTest(int[] source)
        {
            var resultExpected = source.FirstOrDefault();
            var resultActual = source.MyFirstOrDefault();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.FirstOrDefault(resultPredicate);
            resultActual = source.MyFirstOrDefault(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyLastTest(int[] source)
        {
            var resultExpected = source.Last();
            var resultActual = source.MyLast();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.Last(resultPredicate);
            resultActual = source.MyLast(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyLastOrDefaultTest(int[] source)
        {
            var resultExpected = source.LastOrDefault();
            var resultActual = source.MyLastOrDefault();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.LastOrDefault(resultPredicate);
            resultActual = source.MyLastOrDefault(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0 })]
        [InlineData(new[] { 9 })]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { -1 })]
        public void MySingleTest(int[] source)
        {
            var resultExpected = source.Single();
            var resultActual = source.MySingle();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.Single(resultPredicate);
            resultActual = source.MySingle(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 9 })]
        [InlineData(new[] { 0 })]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { -1 })]
        public void MySingleOrDefaultTest(int[] source)
        {
            var resultExpected = source.SingleOrDefault();
            var resultActual = source.MySingleOrDefault();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.SingleOrDefault(resultPredicate);
            resultActual = source.MySingleOrDefault(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyAny(int[] source)
        {
            var resultExpected = source.Any();
            var resultActual = source.MyAny();

            Assert.Equal(resultExpected, resultActual);

            Func<int, bool> resultPredicate = x => x > 5;
            resultExpected = source.Any(resultPredicate);
            resultActual = source.MyAny(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 1, 2, 12, 3, 4, 5, 3, 1 })]
        [InlineData(new[] { -1, -10, 6, 3, 2, -1 })]
        public void MyAll(int[] source)
        {
            Func<int, bool> resultPredicate = x => x > 5;
            var resultExpected = source.All(resultPredicate);
            var resultActual = source.MyAll(resultPredicate);

            Assert.Equal(resultExpected, resultActual);
        }
    }
}