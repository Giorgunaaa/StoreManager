int[] x = { 1, 2, 3, 4, 4, 5 };
int[] y = { 4, 5, 7, 9, 10, 11, 12 };

#region მეორე ეტაპის ამოცანები

//var result1 = x.MyFirst();
//var result2 = x.MyFirst(n => n > 2);
//var result3 = x.MyFirstOrDefault();
//var result4 = x.MyFirstOrDefault(n => n > 2);
//var result5 = x.MyLast();
//var result6 = x.MyLast(n => n < 2);
//var result7 = x.MyLastOrDefault();
//var result8 = x.MyLastOrDefault(n => n < 2);
//var result9 = x.MySingle();
//var result10 = x.MySingle(n => n > 4);
//var result11 = x.MySingleOrDefault();
//var result12 = x.SingleOrDefault(n => n > 4);

var result13 = x.MyAny();
var result14 = x.MyAny(n => n > 2);
var result15 = x.MyAll(n => n > 2);

#endregion


Console.WriteLine(result13);
Console.WriteLine(result14);
Console.WriteLine(result15);




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
//var products = DataProvider.GetTestData();
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