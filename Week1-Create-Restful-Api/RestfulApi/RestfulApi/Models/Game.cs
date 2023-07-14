using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Models
{
    public class Game
    {
        [DisplayName("Game Id")]
        [Required]
        public long Id { get; set; }

        [DisplayName("Game Name")]
        [Required]
        [StringLength(maximumLength: 512, MinimumLength = 1, ErrorMessage = "Oyun adı en az 1, en çok 512 karakter içermelidir...")]
        public string Name { get; set; }

        [DisplayName("Game Description")]
        [StringLength(maximumLength: 8192, MinimumLength = 8, ErrorMessage = "Oyun açıklaması en az 8, en fazla 8192 karakter içermelidir...")]
        public string? Description { get; set; }

        [DisplayName("Game Genre")]
        [StringLength(maximumLength: 256, MinimumLength = 2, ErrorMessage = "Oyun türü en az 2, en fazla 256 karakter içermelidir...")]
        public string? Genre { get; set; }

        [DisplayName("Game Developer")]
        [StringLength(maximumLength: 256, MinimumLength = 2, ErrorMessage = "Oyunun developer bilgisi en az 2, en fazla 256 karakter içermelidir...")]
        public string? Developer { get; set; }

        [DisplayName("Game Publisher")]
        [StringLength(maximumLength: 256, MinimumLength = 2, ErrorMessage = "Oyunun pubisher bilgisi en az 2, en fazla 256 karakter içermelidir...")]
        public string? Publisher { get; set; }

        [DisplayName("Game Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Game Platform")]
        [StringLength(maximumLength: 512, MinimumLength = 2, ErrorMessage = "Oyunun platfrom bilgisi en az 2, en fazla 512 karakter içermelidir...")]
        public string? Platform { get; set; }

        [DisplayName("Game Price ($)")]
        [Range(0, 10000, ErrorMessage = "Oyunun fiyatı en az 0, en fazla 10.000 olmalıdır...")]
        public double? Price { get; set; }
    }

}
