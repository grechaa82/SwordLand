using SwordLand.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwordLand.BusinessLogic.Tests.ModelsCreators
{
    public class CommentCreater
    {
        private static Category _category = Category.Create("string");
        private static Guid _id = Guid.NewGuid();
        private static string _text = "Lorem ipsum dolor sit amet consectetur";
        private static DateTime _date = DateTime.Now;
        private static User _user = User.Create(
            "string",
            "email@email.com",
            "b109f3bbbc244eb82441917ed06d618b9008dd09b3befd1b5e07394c706a8bb980b1d7785e5976ec049b46df5f1326af5a2ea6d103fd07c95385ffab0cacbc86");
        private static Post _post = Post.Create(
            _id, 
            _user, 
            _text, 
            _text, 
            _text, 
            _category, 
            _date, 
            _date, 
            default);
        private static Comment _parentComment = Comment.Create(
            _user, 
            _post, 
            _text, 
            _parentComment);

        private static Comment CreateComment(
            User user,
            Post post,
            string content,
            Comment parentComment)
        {

            var comment = Comment.Create(
                user, 
                post, 
                content, 
                parentComment);

            return comment;
        }

        public static Comment CreateOneComment()
        {
            var result = CreateComment(
                _user, 
                _post, 
                _text, 
                _parentComment);

            return result;
        }

        public static List<Comment> CreateManyComment(int number)
        {
            var result = new List<Comment>();

            for (int i = 0; i < number; i++)
            {
                var comment = CreateComment(
                    _user,
                    _post,
                    _text,
                    _parentComment);

                result.Add(comment);
            };

            return result;
        }
    }
}
