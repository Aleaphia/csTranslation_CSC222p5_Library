using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC222p5_Library
{
	internal class Book
	{
		// Atrributes
		private String title;
		private String author;
		private long ISBN;

		//Constructors
		public Book(String title, String author, long ISBN){
			this.title = title;
			this.author = author;
			this.ISBN = ISBN;
		}

		//Methods
		public String getTitle(){ return this.title; }
		public String getAuthor(){ return this.author; }
		public long getISBN(){ return ISBN; }

		public override string ToString(){
			return $"{title} by {author} (ISBN: {ISBN})";
		}

	}
}
