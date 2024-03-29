﻿namespace EntityDefinitions.Entities;

public class MovieRatings : BaseEntity
{
    /*
     * G – General Audiences: All ages admitted. Nothing that would offend parents for viewing by children.
     * PG – Parental Guidance Suggested: Some material may not be suitable for children. Parents urged to give "parental guidance". May contain some material parents might not like for their young children.
     * PG-13 – Parents Strongly Cautioned:ome material may be inappropriate for children under 13. Parents are urged to be cautious. Some material may be inappropriate for pre-teenagers.
     * R – Restricted : Under 17 requires accompanying parent or adult guardian. Contains some adult material. Parents are urged to learn more about the film before taking their young children with them.
     * NC-17 – Adults Only: No one 17 and under admitted. Clearly adult. Children are not admitted.
    */
    
    public string? RateCode { get; set; }
    public string? RateName { get; set; }
    public string? RateDescription { get; set; } 
}
