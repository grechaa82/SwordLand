using System;
using System.Collections.Generic;

namespace SwordLand.Core.Models
{
    public class Category
    {
        const int MAX_TITLE_LENGTH = 36;

        private Category(
            Guid id, 
            string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        
        public static Category Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException($"{nameof(title)} is incorrect");
            }

            if (!string.IsNullOrWhiteSpace(title)
                && title.Length >= MAX_TITLE_LENGTH)
            {
                throw new ArgumentException($"{nameof(title)} is not be more than {MAX_TITLE_LENGTH} chars");
            }

            var category = new Category(
                Guid.NewGuid(),
                title); 

            return category;
        }
    }
}
