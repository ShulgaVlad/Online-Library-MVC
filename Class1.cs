for (int i = 0; i < 1000000; i++)
{
    Book books = new Book
    {
        book_name = i.ToString(),
        author = i.ToString(),
        book_genre = i.ToString(),
        short_dicription = i.ToString(),
        rating = i.ToString()
    };

    dtbs.Books.Add(user);
}


private void NewAddedBooks()
{
    Stopwatch bookStopwatch = Stopwatch.StartNew();
    IEnumerable<Book> BooksList = dtbs.Books.Take(20);
    bookStopwatch.Stop();
    Console.WriteLine({bookStopwatch.ElapsedMilliseconds});

    var parallelbookStopwatch = Stopwatch.StartNew();
    var parallelbooksList = new List<Book>();
    BooksList.ForEach(parallelbooksList.Add);
    parallelbookStopwatch.Stop();
    Console.WriteLine(parallelbookStopwatch.ElapsedMilliseconds);
}

private void BooksLarge()
{
    Stopwatch bookStopwatch = Stopwatch.StartNew();
    WebApi.RequestBooksLarge();
    bookStopwatch.Stop();
    dtbs.BookStopwatch.ElapsedMilliseconds;
}

private void BookIndexLarge()
{
    IEnumerable<Book> parallelbook = dtbs.Books.Take(100000);
    Stopwatch bookStopwatch = new Stopwatch();
    bookStopwatch.Start();
    parallelReg.ForEach(Add(Book));
    bookStopwatch.Stop();
    dtbs.Books.ElapsedMilliseconds;
}

private async Task BookAsync()
{
    Stopwatch bookStopwatch Stopwatch = StartNow();
    IEnumerable<Book> seqbookasync = await dtbs.Books.Take(100000).ToListAsync();
    bookStopwatch.Stop();

    ViewBag.sequentbooksasync = bookStopwatch.Elapsedmilliseconds;
}

private async Task IndexAsyncPar()
{
    Stopwatch parallelbookStopwatch Stopwatch = StartNew();
    IEnumerable<Book> parbookasync = await Task.Run(() => dbContext.Books.Take(100000).ToList());
    parallelbookStopwatch.Stop();

    ViewBag.parallelparbookasync = parallelbookStopwatch.ElapsedRilliseconds;
}
