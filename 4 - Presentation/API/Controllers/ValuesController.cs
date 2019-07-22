using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Reaction_api.Presentation.Controllers {
    [Route ("api/moments2")]
    public class ValuesController : Controller {
        // GET api/values
        [HttpGet]
        public IEnumerable<Moment> Get () {
            var user = new User (
                name: "caiocolaiacovo",
                profile: "http://localhost:3000/users/caiocolaiacovo",
                avatar: "https://avatars1.githubusercontent.com/u/13860945?s=400&u=2fa35c54ffa45578eaa8d0453d41fab34ef8e8fa&v=4"
            );
            var user2 = new User (
                name: "octocat",
                profile: "http://localhost:3000/users/octocat",
                avatar: "https://avatars1.githubusercontent.com/u/583231?s=400&v=4"
            );

            var comment = new Comment (
                user: user,
                text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sagittis nisi in sapien fermentum euismod"
            );

            return new List<Moment> {
                new Moment (
                    id: 1,
                    user: user,
                    elapsedTime: "25 MINUTES AGO",
                    picture: "https://i1.wp.com/www.k9magazine.com/wp-content/uploads/YuCALM_Dog_Master1_Print.jpg?resize=1000%2C600",
                    reactions : 10,
                    comments : new Comment[] { comment, comment }
                ),
                new Moment (
                    id: 1,
                    user: user,
                    elapsedTime: "50 MINUTES AGO",
                    picture: "http://cdn7.viralscape.com/wp-content/uploads/2015/02/Dog-Portrait-15.jpg",
                    reactions : 27,
                    comments : new Comment[] { comment, comment }
                ),
                new Moment (
                    id: 1,
                    user: user2,
                    elapsedTime: "1 HOUR AGO",
                    picture: "https://iso.500px.com/wp-content/uploads/2016/11/stock-photo-159533631-1500x1000.jpg",
                    reactions : 13,
                    comments : new Comment[] { comment, comment }
                )
            };
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public object Get (int id, [FromQuery] int pagina) {
            return new {
                data = new string[] { },
                    totalDePaginas = 15,
                    paginaAtual = pagina,
            };
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }

    public class Moment {
        public Moment (int id, User user, string elapsedTime, string picture, int reactions, Comment[] comments) {
            this.id = id;
            this.user = user;
            this.elapsedTime = elapsedTime;
            this.picture = picture;
            this.reactions = reactions;
            this.comments = comments;
        }

        public int id { get; set; }
        public User user { get; set; }
        public string elapsedTime { get; set; }
        public string picture { get; set; }
        public int reactions { get; set; }
        public IEnumerable<Comment> comments { get; set; }
    }

    public class User {
        public User (string name, string profile, string avatar) {
            this.name = name;
            this.profile = profile;
            this.avatar = avatar;
        }

        public string name { get; set; }
        public string profile { get; set; }
        public string avatar { get; set; }
    }
    public class Comment {
        public Comment (User user, string text) {
            this.user = user;
            this.text = text;
        }

        public User user { get; set; }
        public string text { get; set; }
    }
}