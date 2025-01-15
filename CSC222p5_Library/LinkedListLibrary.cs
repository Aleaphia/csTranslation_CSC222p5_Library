using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC222p5_Library
{
	internal class LinkedListLibrary
	{
		//Attributes
		BookNode headNode;

		//Construcutor
		public LinkedListLibrary(){
			headNode = null;
		}

		public int sortedInsert(Book newBook){
			int operationCoutner = 0;
			BookNode currNode;
			BookNode nextNode;

			if(headNode == null || headNode.getBook().getISBN() >= newBook.getISBN()) {
				headNode = new BookNode(newBook, headNode); //Set headNode to a new populated bookNode that points to the old headNode
				operationCoutner++;
			}
			else{
				//Locate the correct position
				currNode = headNode;

				while (currNode.getNext() != null && currNode.getNext().getBook().getISBN() < newBook.getISBN()) {
					currNode = currNode.getNext();
				}
				currNode.insertAfter(new BookNode(newBook));

				operationCoutner++;
			}

			return operationCoutner;
		}

		public void printLibrary(){
			BookNode currNode;
			currNode = headNode;
			while(currNode != null){
				Console.WriteLine(currNode.getBook());
				currNode = currNode.getNext();
			}
		}


		internal class BookNode{
			//Attributes	
			private Book book = null;
			private BookNode nextNode = null;

			//Constructors
			public BookNode(Book book){ this.book = book;}
			public BookNode(Book book, BookNode nextNode) {
				this.book = book;
				this.nextNode = nextNode;
			}
			public BookNode(String bookTitle, String bookAuthor, long bookISBN) {
				this.book = new Book(bookTitle, bookAuthor, bookISBN);
			}
			public BookNode(String bookTitle, String bookAuthor, long bookISBN, BookNode nextNode) {
				this.book = new Book(bookTitle, bookAuthor, bookISBN);
				this.nextNode = nextNode;
			}

			//Methods
			public void insertAfter(BookNode newNode) {
				BookNode tmpNext = this.nextNode;
				this.nextNode = newNode;
				newNode.nextNode = tmpNext;
			}
			public void setNext(BookNode nextNode) { this.nextNode = nextNode; }
			public BookNode getNext() { return this.nextNode; }
			public Book getBook() { return this.book; }
		}
	}
}
