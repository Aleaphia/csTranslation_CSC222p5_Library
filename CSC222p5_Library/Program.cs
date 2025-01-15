/*
 * CSC 222 Assignment 5: Library Lists
 * Finish main to insert a new book into an array list and a linked list library.
 */
namespace CSC222p5_Library{
	public class LibraryInterface{
		

		internal static void fillLibraries(LinkedListLibrary lll, ArrayListLibrary all) {
			int lllOperations = 0;
			int allOperations = 0;
			
			var bookInfo = File.ReadAllLines("Books.txt");
			for (int i = 0; i < bookInfo.Length; i += 3 ){
				String name = bookInfo[i];
				String author = bookInfo[i + 2];
				long ISBN = long.Parse(bookInfo[i + 1]);

				Book newBook = new(name, author, ISBN);

				allOperations += all.sortedInsert(newBook);
				lllOperations += lll.sortedInsert(newBook);
			}
			Console.WriteLine($"arrayList operations: {allOperations}\nlinkedList operations: {lllOperations}\n");
		}

		internal static void addBook(LinkedListLibrary lll, ArrayListLibrary all){
			int lllOperations = 0;
			int allOperations = 0;

			Book book = createBook();

			lllOperations = lll.sortedInsert(book);
			allOperations = all.sortedInsert(book);

			Console.WriteLine($"arrayList operations: {allOperations}\nlinkedList operations: {lllOperations}\n");
		}

		internal static Book createBook(){
			Console.Write("Enter book name: ");
			String name = Console.ReadLine();
			Console.Write("Enter author name: ");
			String author = Console.ReadLine();
			Console.Write("Enter ISBN: ");
			long ISBN = long.Parse(Console.ReadLine());
			return new(name,author,ISBN);
		}

		static void Main(String[] args) {
			int lllOperations = 0;
			int allOperations = 0;

			// Create libraries
			LinkedListLibrary lll = new LinkedListLibrary();
			ArrayListLibrary all = new ArrayListLibrary();

			// Fill libraries with 100 books
			fillLibraries(lll, all);

			Console.WriteLine("Would you like to add another book? (y/n)");
			while (Console.ReadLine()[0] == 'y'){
				addBook(lll, all);
				Console.WriteLine("Would you like to add another book? (y/n)");
			}
			
		}
	}
}
