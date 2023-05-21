﻿namespace PokemanWebApi.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public Reviewer Reviewer { get; set; } = null!;
        public Pokeman Pokeman { get; set; } = null!;
    }
}
