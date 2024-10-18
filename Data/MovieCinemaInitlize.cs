// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using CinemaMovieWebApplication.Models.Entities;
// using CinemaMovieWebApplication.Models.Enums;

// namespace CinemaMovieWebApplication.Data
// {
//     public class MovieCinemaInitlize
//     {
//         public static void Seeding(IServiceProvider provider) {
//             using (var applicationServices = provider.CreateScope()){
//                 var context = applicationServices.ServiceProvider.GetRequiredService<MovieCinemaDbContext>();

//                 context.Database.EnsureCreated();
                
//                 // ........ adding inital values to actor table ............//
//                 if(!context.Actors.Any()){
//                      var actor1 = new ActorModel{
                       
//                             ProfileImage = "~/assets/actorsImages/LeonardoDiCaprio.webp", FullName = "Leonardo DiCaprio", 
//                             AwardCount = 2, bio = "Leonardo DiCaprio is an American actor and producer known for his diverse roles and outstanding performances. He gained international fame with Titanic (1997) and has since starred in critically acclaimed films like Inception (2010), The Wolf of Wall Street (2013), and The Revenant (2015), for which he won an Academy Award."
//                     };

//                     var actor2 = new ActorModel{
//                             ProfileImage = "~/assets/actorsImages/ScarlettJohansson.jpeg", FullName = "Scarlett Johansson", 
//                             AwardCount = 3, bio = "Scarlett Johansson is an American actress and singer, famous for her versatility and compelling performances in a range of genres. She became a global star with her role as Black Widow in the Marvel Cinematic Universe and received critical acclaim for films like Marriage Story (2019) and Lost in Translation (2003)."
//                     };

//                     var actor3 = new ActorModel{
//                             ProfileImage = "~/assets/actorsImages/RobertDowney.jpeg", FullName = "Robert Downey Jr.", 
//                             AwardCount = 5, bio = "Robert Downey Jr. is an American actor and producer who made a major comeback after overcoming personal struggles, becoming one of the most beloved actors in Hollywood. He is best known for his portrayal of Tony Stark/Iron Man in the Marvel Cinematic Universe and for his roles in films like Sherlock Holmes and Tropic Thunder."
//                     };

//                     var actor4 = new ActorModel{
//                             ProfileImage = "~/assets/actorsImages/AngelinaJolie.jpeg", FullName = "Angelina Jolie", 
//                             AwardCount = 5, bio = "Angelina Jolie is an American actress, filmmaker, and humanitarian known for her powerful on-screen presence. She won an Academy Award for Girl, Interrupted (1999) and achieved worldwide recognition with Lara Croft: Tomb Raider (2001). She has also directed films and is known for her humanitarian work."
//                     };
//                     context.AddRange(actor1, actor2, actor3, actor4);
//                     context.SaveChanges();
//                 }

//                 // ........ adding inital values to cinema table ...........//
//                 if(!context.Cinemas.Any()) {
//                     var cinema1 = new CinemaModel {
//                         Logo = "~/assets/CinemasImages/CinemagicPalace.jpg", Name = "Cinemagic Palace",  Description = "Cinemagic Palace is a premier cinema offering the latest movies in a luxurious environment. We pride ourselves on providing an unforgettable cinematic experience with state-of-the-art technology and comfortable seating.", 
//                         Location = "123 Movie Lane, Film City, CA 90210, USA", PhoneNumber = "(123) 456-7890", 
//                         OpeningHours = "Monday to Thursday: 10:00 AM - 11:00 PM", Website = "https://www.palacecinemas.com.au/movies", 
//                         Email = "contact@cinemagicpalace.com", 
//                         Facilities = new List<string> {"VIP Seating", "3D Movies", "IMAX Experience", "Concessions Stand", "Online Booking", "Private Screening Rooms", "Wheelchair Accessibility"}, 
//                     };

//                     var cinema2 = new CinemaModel {
//                         Logo = "~/assets/CinemasImages/SilverScreenTheater.png", Name = "Silver Screen Theater",  Description = "Silver Screen Theater offers a classic cinema experience with modern amenities. Enjoy a wide range of films from blockbusters to indie gems in our comfortable auditoriums.", 
//                         Location = "456 Silver St, Movie Town, NY 10001, USA", PhoneNumber = "(234) 567-8901", 
//                         OpeningHours = "Monday to Thursday: 12:00 PM - 10:00 PM", Website = "https://www.silverscreenvii.com/", 
//                         Email = "info@silverscreentheater.com", 
//                         Facilities = new List<string> {"Premium Seats", "4D Experience", "IMAX Experience", "Concessions Stand", "Family-Friendly Screenings"}, 
//                     };

//                      var cinema3 = new CinemaModel {
//                         Logo = "StartView Cinema", Name = "Starview Cinemas",  Description = "At Starview Cinemas, we combine the latest technology with a cozy atmosphere. Enjoy movies in our state-of-the-art screening rooms equipped with the latest sound and projection technology.", 
//                         Location = "789 Starview Ave, Film City, CA 90212, USA", PhoneNumber = "(345) 678-9012", 
//                         OpeningHours = "Monday to Thursday: 11:00 AM - 10:00 PM", Website = "https://www.lukeworthsholdings.com/", 
//                         Email = "support@starviewcinemas.com", 
//                         Facilities = new List<string> {"VIP Lounges", "3D and 4DX Screens", "Full Bar", "Kids Play Area", "Group Discounts"}, 
//                     };

//                     var cinema4 = new CinemaModel {
//                         Logo = "~/assets/CinemasImages/RegalCinemas.webp", Name = "Regal Cinemas",  Description = "Regal Cinemas is known for its premier film experience. With multiple screens showcasing the latest films, you'll always find something to watch with us.", 
//                         Location = "321 Regal Rd, Entertainment District, TX 73301, USA", PhoneNumber = "(456) 789-0123", 
//                         OpeningHours = "Monday to Thursday: 11:00 AM - 10:00 PM", Website = "https://www.regmovies.com/", 
//                         Email = "customer.service@regalcinemas.com", 
//                         Facilities = new List<string> {"IMAX Experience", "Dine-In Theaters", "Arcade Area", "Online Reservations"}, 
//                     };

//                     context.AddRange(cinema1, cinema2, cinema3, cinema4); 
//                     context.SaveChanges();
//                 }
                
//                 // ........ adding inital values to producer table ......... //
//                 if(!context.Producers.Any()) {
//                     var Producer1 = new ProducerModel {
//                         ProducerProfileImage = "~/assets/Producer/ChristopherNolan.jpg",
//                         ProducerName = "Christopher Nolan",
//                         bio = "Christopher Nolan is a British-American film director, producer, and screenwriter known for his innovative storytelling and visually striking films. His works often explore complex themes and have garnered critical acclaim.",
//                     };
                    
//                     var Producer2 = new ProducerModel {
//                         ProducerProfileImage = "~/assets/Producer/FrankDarabont.jpeg",
//                         ProducerName = "Frank Darabont",
//                         bio = "Frank Darabont is an American film director, producer, and screenwriter, best known for his work on films such as 'The Shawshank Redemption' and 'The Green Mile.' He is recognized for his ability to adapt literary works into powerful cinematic experiences.",
//                     };

//                     var Producer3 = new ProducerModel {
//                         ProducerProfileImage = "~/assets/Producer/RobertZemeckis.jpeg",
//                         ProducerName = "Robert Zemeckis",
//                         bio = "Robert Zemeckis is an American filmmaker known for his pioneering use of visual effects in films. His notable works include 'Forrest Gump' and the 'Back to the Future' trilogy, which blend innovative storytelling with technological advancements.",
//                     };

//                     var Producer4 = new  ProducerModel {
//                         ProducerProfileImage = "~/assets/Producer/StevenSpielberg.webp",
//                         ProducerName = "Steven Spielberg",
//                         bio = "Steven Spielberg is an American film director, producer, and screenwriter, regarded as one of the founding pioneers of the modern film industry. His films often tackle themes of childhood and family and include classics such as 'E.T.' and 'Jurassic Park.'",
//                     };

//                     context.AddRange(Producer1, Producer2, Producer3, Producer4);
//                     context.SaveChanges();
//                 }
            
//                 // ........ adding inital values to Movies table ...........//
//                 if(!context.Movies.Any()){
//                     // Get the existing producer IDs
//                     var producer1Id = context.Producers.FirstOrDefault(p => p.ProducerName == "Christopher Nolan")?.Id;
//                     var producer2Id = context.Producers.FirstOrDefault(p => p.ProducerName == "Frank Darabont")?.Id;
//                     var producer3Id = context.Producers.FirstOrDefault(p => p.ProducerName == "Robert Zemeckis")?.Id;
//                     var producer4Id = context.Producers.FirstOrDefault(p => p.ProducerName == "Steven Spielberg")?.Id;

//                     var Movie1 =  new MovieModel
//                     {
//                         Title = "Inception",
//                         Description = "A skilled thief is given a chance at redemption if he can successfully perform inception: planting an idea into a target's subconscious.",
//                         Price = 14.99m,
//                         MovieUrl = "https://www.warnerbros.com/movies/inception",
//                         Rating = 8.8m,
//                         Duration = 148, // in minutes
//                         ReleaseDate = new DateTime(2010, 7, 16),
//                         MovieTypes =  MovieTypes.Action,
//                         Language = "English",
//                         Director = "Christopher Nolan",
//                         ProductionCompany = "Warner Bros.", 
//                         MoviePoster = "~/assets/MovieImages/Inception.jpeg", 
//                         ProducerId = producer1Id ?? throw new InvalidOperationException("Producer not found") // Use the producer ID from above,
//                     };

//                     var Movie2 = new MovieModel {
//                         Title = "The Shawshank Redemption",
//                         Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
//                         Price = 12.99m,
//                         MovieUrl = "https://www.imdb.com/title/tt0111161/",
//                         Rating = 9.3m,
//                         Duration = 142,
//                         ReleaseDate = new DateTime(1994, 9, 23),
//                         MovieTypes = MovieTypes.Drama,
//                         Language = "English",
//                         Director = "Frank Darabont",
//                         ProductionCompany = "Castle Rock Entertainment",
//                         MoviePoster = "~/assets/MovieImages/ShawshankRedemption.jpeg", 
//                         ProducerId = producer2Id ?? throw new InvalidOperationException("Producer not found") // Use the producer ID from above,
//                     };

//                     var Movie3 = new  MovieModel {
//                         Title = "The Dark Knight",
//                         Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
//                         Price = 14.99m,
//                         MovieUrl = "https://www.imdb.com/title/tt0468569/",
//                         Rating = 9.0m,
//                         Duration = 152,
//                         ReleaseDate = new DateTime(2008, 7, 18),
//                         MovieTypes = MovieTypes.Action,
//                         Language = "English",
//                         Director = "Christopher Nolan",
//                         ProductionCompany = "Warner Bros.",
//                         MoviePoster = "~/assets/MovieImages/DarkKnight.jpeg",
//                         ProducerId = producer3Id ?? throw new InvalidOperationException("Producer not found") // Use the producer ID from above,
//                     };

//                     var Movie4 = new MovieModel {
//                         Title = "Forrest Gump",
//                         Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold through the perspective of an Alabama man with an IQ of 75.",
//                         Price = 9.99m,
//                         MovieUrl = "https://www.imdb.com/title/tt0109830/",
//                         Rating = 8.8m,
//                         Duration = 142,
//                         ReleaseDate = new DateTime(1994, 7, 6),
//                         MovieTypes = MovieTypes.Comedy, // Assuming MovieType is an enum with defined values
//                         Language = "English",
//                         Director = "Robert Zemeckis",
//                         ProductionCompany = "Paramount Pictures",
//                         MoviePoster = "~/assets/MovieImages/ForrestGump.jpg",
//                         ProducerId = producer4Id ?? throw new InvalidOperationException("Producer not found") // Use the producer ID from above,
//                     };

//                     context.AddRange(Movie1, Movie2, Movie3, Movie4);
//                     context.SaveChanges();
//                 }

//                 // ........ adding inital values to actor movie table ........ //
//                 if(!context.ActorMovies.Any()) {
//                      var ActorMovie1 = new ActorMovieModel {
//                         ActorId = 1, 
//                         MovieId = 1,
//                     };

//                     var ActorMovie2 = new ActorMovieModel {
//                         ActorId = 2, 
//                         MovieId = 2,
//                     };

//                     var ActorMovie3 = new ActorMovieModel {
//                         ActorId = 3, 
//                         MovieId = 3,
//                     };

//                     var ActorMovie4 = new ActorMovieModel {
//                         ActorId = 4, 
//                         MovieId = 4,
//                     };

//                     context.AddRange(ActorMovie1, ActorMovie2, ActorMovie3, ActorMovie4); 
//                     context.SaveChanges();
//                 }
            
//                 // ......... adding inital values to movie cinema tabe ......... //
//                 if(!context.MovieCinema.Any()){
//                     var MovieCinema1 = new MovieCinemaModel {
//                         MovieId = 1, CinemaId = 1
//                     }; 

//                     var MovieCinema2 = new MovieCinemaModel {
//                         MovieId = 2, CinemaId = 2
//                     }; 

//                     var MovieCinema3 = new MovieCinemaModel {
//                         MovieId = 3, CinemaId = 3
//                     }; 

//                     var MovieCinema4 = new MovieCinemaModel {
//                         MovieId = 4, CinemaId = 4
//                     }; 

//                     context.AddRange(MovieCinema1, MovieCinema2, MovieCinema3, MovieCinema4); 
//                     context.SaveChanges();
//                 }
//             }
//         }
//     }
// }