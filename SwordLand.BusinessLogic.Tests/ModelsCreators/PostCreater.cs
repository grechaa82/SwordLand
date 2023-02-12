using SwordLand.Core.Models;
using System;
using System.Collections.Generic;

namespace SwordLand.BusinessLogic.Tests.ModelsCreators
{
    public class PostCreater
    {
        private static User _user = User.Create
        (
            "string",
            "email@email.com",
            "b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86"
        );
        private static Category _category = Category.Create("string");
        private static Guid _id = Guid.NewGuid();
        private static string _text = "Lorem ipsum dolor sit amet consectetur";
        private static DateTime _date = DateTime.Now;

        private static Post CreatePost (
            Guid id, 
            User user,
            Category category, 
            bool isPublished = true)
        {

            var post = Post.Create(
                Guid.NewGuid(),
                user,
                _text,
                _text,
                _text,
                category,
                _date,
                _date,
                isPublished
                );

            return post;
        }

        public static Post CreateOnePost()
        {
            var result = CreatePost(
                _id,
                _user,
                _category, 
                default);

            return result;
        }

        public static List<Post> CreateManyPost(int number)
        {
            var result = new List<Post>();

            for (int i = 0; i < number; i++)
            {
                var post = CreatePost(
                    _id,
                    _user,
                    _category,
                    default);

                result.Add(post);
            };

            return result;
        }
    }
}
