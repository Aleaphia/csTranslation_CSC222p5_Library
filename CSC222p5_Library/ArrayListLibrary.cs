using System.Diagnostics.Metrics;

namespace CSC222p5_Library
{
	internal class ArrayListLibrary{
		//Attributes
		List<Book> library = new();

		//Methods
		public int sortedInsert(Book newBook) {
			int operationCounter = 0;
			Book currBook;

			//Add book to end of list
			library.Add(newBook);

			//Loop through elements starting at the end
			for (int i = library.Count - 2; i >= 0; i--) {
				currBook = library[i];

				// locate position
				if (currBook.getISBN() > newBook.getISBN()) {
					library[i+1] = currBook;
					operationCounter++;
				}
				else{
					library[i + 1] = newBook;
					return ++operationCounter;
				}
			}

			//If we get to the top of the list -> place newBook on top
			library[0] = newBook;
			return ++operationCounter;
		}
		public void printLibary(){
            foreach (var book in library){
				Console.WriteLine(book);
            }
        }
	}
}
