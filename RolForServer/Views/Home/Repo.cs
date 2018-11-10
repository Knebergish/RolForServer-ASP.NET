using System;
using System.Collections.Generic;
using RolForServer.Models;

namespace RolForServer.Views.Home {
    public static class Repo {
        public static List<News> News = new List<News> {
            new News {
                Title = "Новость века", Date = DateTime.Now, AuthorId = 0,
                Text =
                    "Ну тут что-то написано. Очень много текста, его не так-то просто прочитать. Но читать придётся, потому что иначе зачем это всё было написано, как не для почитать?"
            },
            new News {
                Title = "Эта новость достаточно хороша", Date = DateTime.Now, AuthorId = 0,
                Text =
                    "Новости бывают разные: хорошие, плохие. Но эта новость - исключение из всех них. " +
                    "Она настолько великолепна, что от её чтения невозможно оторваться.<br>" +
                    "Её стиль, её шарм, её заумные слова, которые заставят вас поверить в умность автора. " +
                    "Это просто великолепно."
            }
        };

        public static List<User> Users = new List<User> {
            new User {
                Name = "Аллар Кнебергиш", Description = "Является действующим техножрецом Адептус Механикус. В свободное время любит славить Омниссию и выпивать освящённое машинное масло.", AvatarImageName = "Techpriest.jpg"
            },
            new User {Name = "Тея", Description = "Целитель днем, в ночи некромант. Постоялец каморки в таверне \"Огонек\", работница библиотеки. ", AvatarImageName = "Teya.jpg"},
            new User {Name = "Алиум", Description = "Охотник на нежить. Для него добра и зла как такового нет, потому поддерживает свою сторону, истребляя нечисть. ", AvatarImageName = "Alium.jpg"}
        };

        public static List<Forum> Forums = new List<Forum> {
            new Forum {Id = 0, Title = "Таверна", AuthorId = 0, ImageName = "T.jpg"},
            new Forum {Id = 1, Title = "Дверь в будущее", AuthorId = 2, ImageName = "door.jpg"},
            new Forum {Id = 2, Title = "У одинокого дерева", AuthorId = 0, ImageName = "tree.png"},
            new Forum {Id = 3, Title = "А вдруг?..", AuthorId = 0, ImageName = "raptor.png"}
        };

        public static List<Message> Messages = new List<Message> {
            new Message {
                ForumId = 0, UserId = 0, Date = DateTime.Now,
                Text = "Приветствую всех в этом популярнейшем заведении. Кто-нибудь хочет высказаться?"
            },
            new Message {
                ForumId = 0, UserId = 1, Date = DateTime.MinValue,
                Text = "Да, у меня есть что сказать. Почему в этой таверне нет еды?"
            },
            new Message {
                ForumId = 0, UserId = 0, Date = DateTime.Now,
                Text =
                    "Да, в этой таверне нет еды в привычном смысле этого слова. Здесь присутствует только еда для ума, но не для тела."
            },
            new Message {
                ForumId = 0, UserId = 1, Date = DateTime.Now, Text = "Странная у вас таверна, мне не нравится."
            },
            new Message {ForumId = 0, UserId = 2, Date = DateTime.Now, Text = "Даже выпить нечего."},
            new Message {
                ForumId = 1, UserId = 2, Date = DateTime.Now,
                Text =
                    "И вот, после всех ваших злоключений, вы стоите перед дверью. Откроете ли вы её, или уйдёте, не заглянув?"
            },
            new Message {
                ForumId = 1, UserId = 1, Date = DateTime.Now, Text = "Тея подходит к двери и тихонечко стучит в неё."
            },
            new Message {
                ForumId = 1, UserId = 0, Date = DateTime.Now,
                Text = "Аллар находится рядом с Теей на случай внезапного возникновения опасности."
            },
            new Message {
                ForumId = 1, UserId = 2, Date = DateTime.Now,
                Text =
                    "После стука Теи дверь медленно, со скрипом приоткрывается, и вы видите за нею... ничего. У вас нет будущего."
            },
            new Message {
                ForumId = 2, UserId = 0, Date = DateTime.Now,
                Text =
                    "После долгих путешествий по множеству миров, вы наконец-то присели отдохнуть у одиноко стоящего в поле дерева. Его раскидистые ветви надёжно защищали ваш отряд от палящих лучей дневного солнца. Разбив небольшой лагерь в его тени, вы приготовились отдыхать."
            },
            new Message {
                ForumId = 2, UserId = 2, Date = DateTime.Now,
                Text = "Еда была превыше всего. Алиум потрошит свою сумку в поисках чего-либо съестного."
            },
            new Message {
                ForumId = 2, UserId = 1, Date = DateTime.Now,
                Text =
                    "Красота дерева, поля, и окружающей природы заворожила Тею. Она садится у корней дерева и молча наблюдает."
            },
            new Message {
                ForumId = 2, UserId = 0, Date = DateTime.Now,
                Text =
                    "Алиум находит в сумке горсть сухарей и флягу с гранатовым соком.<br>Спокойствие окружения завораживает Тею, и она постепенно засыпает."
            },
            new Message {
                ForumId = 2, UserId = 2, Date = DateTime.Now,
                Text =
                    " - О, фляга.<br>Алиум залпом выпивает содержимое найденного сосуда и начинает медленно грызть сухари."
            },
            new Message {ForumId = 3, UserId = 0, Date = DateTime.Now, Text = "Нет, случайностей не бывает, смирись."}
        };
    }
}