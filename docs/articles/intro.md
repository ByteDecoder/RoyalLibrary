# Examples and usage

```csharp
var myArray = new[] { 1, 45, 34, 435 };

// Evens and odds
myArray.Evens();
myArray.Odds();

// Sum
myArray.TotalAllEvens();
myArray.TotalAllOdds();

// Times
5.Times(_ => {
  var theVar = 13;
  Debug.Log($"This is {theVar}");
});

// Sequences, IEnumerable<T>

// Each
myArray.ForEach(item => Debug.Log($"Using the strength: {item}"));

string[] shapes = { "circle", "square", "triangle", "octagon" };

shapes.ForEach(shape => {
  shape = shape.ToUpper();
  Debug.Log(shape);
});

// Each with Index
shapes.ForEach((item, index) => {
  Debug.Log($"Item: {item.ToUpper()} with index: {index}");
});

// Map
myArray.Map(item => item * 2).Each(item => Debug.Log($"Using the strength doubled: {item}"));

// Max Element in the sequence
var maxBook = SampleData.Books.MaxElement(book => book.PageCount);
Console.WriteLine($"Max Book Page Count => {maxBook.Title}");

// Deferred Execution with StreamReader sequences
using var reader = new StreamReader("books.csv");

Data =
  from line in reader.Lines()
  where !line.StartsWith("#")
  let parts = line.Split(',')
  select new { Title = parts[1], Publisher = parts[3], Isbn = parts[0] };

// Indexes
// 10011001000
IList<bool> source = new List<bool> { true, false, false, true, true, false, false, true, false, false, false };
Data = source.TopIndexes(element => element, 4);

```