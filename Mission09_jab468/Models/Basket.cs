﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jab468.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        public virtual void AddItem(Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty

                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public virtual void RemoveItem (Book book)
            {
                Items.RemoveAll(b => b.Book.BookId == book.BookId);
            }
        public virtual void ClearBasket()
            {
                Items.Clear();
        }

    public double CalculateTotal()
    {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
    }
}
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}