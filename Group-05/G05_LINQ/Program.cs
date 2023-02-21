int[] x = { 1, 2, 3, 4, 4, 5 };
int[] y = { 4, 5, 7, 9, 10, 11, 12 };

#region მეორე ეტაპის ამოცანები

var result1 = x.First();
var result2 = x.First(n => n > 2);
var result3 = x.FirstOrDefault();
var result4 = x.FirstOrDefault(n => n > 2);
var result5 = x.Last();
var result6 = x.Last(n => n > 2);
var result7 = x.LastOrDefault();
var result8 = x.LastOrDefault(n => n > 2);
var result9 = x.Single();
var result10 = x.Single(n => n > 2);
var result11 = x.SingleOrDefault();
var result12 = x.SingleOrDefault(n => n > 2);

var result13 = x.Any();
var result14 = x.Any(n => n > 2);
var result15 = x.All(n => n > 2);

#endregion

#region პირველი ეტაპის ამოცანები
/*
Console.WriteLine("Union");
var result1 = x.Union(y);
result1.ToList().ForEach(Console.WriteLine);

Console.WriteLine("Concat");
var result2 = x.Concat(y);
result2.ToList().ForEach(Console.WriteLine);

Console.WriteLine("Except");
var result3 = x.Except(y);
result3.ToList().ForEach(Console.WriteLine);

Console.WriteLine("Intersect");
var result4 = x.Intersect(y);
result4.ToList().ForEach(Console.WriteLine);

Console.WriteLine("Distinct");
var result5 = x.Distinct();
result5.ToList().ForEach(Console.WriteLine); 
*/
#endregion

//TODO: create own implementation in MyEnumerable for the following methods: 
//Union, Concat, Except, Intersect.
//As example use MyWhere method.

//-----------------------------------------------------------
var products = DataProvider.GetTestData();
//products.ToList().ForEach(Console.WriteLine);

//var result = products
//    .Where(p => p.Price < 2)
//    .OrderBy(p => p.Price);

//var result = from p in products
//             where p.Price < 2
//             orderby p.Price
//             select p;

//var result = products
//    .MyWhere(p => p.Price < 2);

//result.ToList().ForEach(Console.WriteLine);