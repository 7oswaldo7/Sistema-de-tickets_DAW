using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTicketsDB.Models
{
    public class roles
    {
        [Key]
        public int id_rol { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre_rol { get; set; }

        [MaxLength(300)]
        public string? descripcion_rol { get; set; }

        public virtual ICollection<empleados>? empleados { get; set; }
    }

    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre { get; set; }

        [MaxLength(30)]
        public string? genero { get; set; }

        [MaxLength(20)]
        public string? telefono { get; set; }

        [Required]
        [MaxLength(100)]
        public string correo_electronico { get; set; }

        [MaxLength(255)]
        public string? contrasena { get; set; }

        public virtual ICollection<empleados>? empleados { get; set; }
        public virtual ICollection<servicio_cliente>? servicio_cliente { get; set; }
        public virtual ICollection<tickets>? tickets { get; set; }
    }

    public class empleados
    {
        [Key]
        public int id_empleado { get; set; }

        public int id_usuario { get; set; }

        public int id_rol { get; set; }

        [ForeignKey(nameof(id_rol))]
        public virtual roles roles { get; set; }

        [ForeignKey(nameof(id_usuario))]
        public virtual usuarios usuarios { get; set; }

        public virtual ICollection<asignacion_tickets>? asignacion_tickets { get; set; }
    }

    public class servicio_cliente
    {
        [Key]
        public int id_servicio_cliente { get; set; }

        public int id_usuario { get; set; }

        [Required]
        [MaxLength(300)]
        public string nombre_del_problema { get; set; }

        [MaxLength(300)]
        public string? descripcion_del_problema { get; set; }

        [MaxLength(150)]
        public string? fecha_del_probelma { get; set; }

        [ForeignKey(nameof(id_usuario))]
        public virtual usuarios usuarios { get; set; }

        public virtual ICollection<servicios>? servicios { get; set; }
    }

    public class categorias_servicios
    {
        [Key]
        public int id_categoria_servicio { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre_categoria { get; set; }

        [MaxLength(255)]
        public string? descripcion { get; set; }

        public virtual ICollection<servicios>? servicios { get; set; }
    }

    public class estado_servicios
    {
        [Key]
        public int id_estado_servicio { get; set; }

        [Required]
        [MaxLength(50)]
        public string estado { get; set; }

        public virtual ICollection<servicios>? servicios { get; set; }
    }

    public class servicios
    {
        [Key]
        public int id_servicio { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre_servicio { get; set; }

        [MaxLength(255)]
        public string? descripcion { get; set; }

        public int id_categoria_servicio { get; set; }

        public int id_estado_servicio { get; set; }

        public int? id_servicio_cliente { get; set; }

        [ForeignKey(nameof(id_categoria_servicio))]
        public virtual categorias_servicios? categorias_servicios { get; set; }

        [ForeignKey(nameof(id_estado_servicio))]
        public virtual estado_servicios? estado_servicios { get; set; }

        [ForeignKey(nameof(id_servicio_cliente))]
        public virtual servicio_cliente? servicio_cliente { get; set; }

        public virtual ICollection<tickets>? tickets { get; set; }
    }

    public class prioridades_tickets
    {
        [Key]
        public int id_prioridad { get; set; }

        [Required]
        [MaxLength(50)]
        public string nivel_prioridad { get; set; }

        [MaxLength(255)]
        public string? descripcion { get; set; }

        public virtual ICollection<tickets>? tickets { get; set; }
    }

    public class estado_tickets
    {
        [Key]
        public int id_estado_ticket { get; set; }

        [Required]
        [MaxLength(50)]
        public string estado { get; set; }

        [MaxLength(255)]
        public string? descripcion { get; set; }

        public virtual ICollection<tickets>? tickets { get; set; }
    }

    public class Categorias_tickets
    {
        [Key]
        public int id_categoria_ticket { get; set; }

        [Required]
        [MaxLength(100)]
        public string nombre_categoria { get; set; }

        [MaxLength(255)]
        public string? descripcion { get; set; }

        public virtual ICollection<tickets>? tickets { get; set; }
    }

    public class tickets
    {
        [Key]
        public int id_ticket { get; set; }

        [Required]
        [MaxLength(255)]
        public string titulo { get; set; }

        [Required]
        [MaxLength(1000)]
        public string descripcion { get; set; }

        [Required]
        public DateTime fecha_creacion { get; set; }

        public DateTime? fecha_cierre { get; set; }

        public int id_usuario { get; set; }

        public int id_categoria_ticket { get; set; }

        public int id_estado_ticket { get; set; }

        public int id_prioridad { get; set; }

        public int id_servicio { get; set; }

        [ForeignKey(nameof(id_usuario))]
        public virtual usuarios usuarios { get; set; }

        [ForeignKey(nameof(id_categoria_ticket))]
        public virtual Categorias_tickets Categorias_tickets { get; set; }

        [ForeignKey(nameof(id_estado_ticket))]
        public virtual estado_tickets estado_tickets { get; set; }

        [ForeignKey(nameof(id_prioridad))]
        public virtual prioridades_tickets prioridades_tickets { get; set; }

        [ForeignKey(nameof(id_servicio))]
        public virtual servicios servicios { get; set; }

        public virtual ICollection<asignacion_tickets>? asignacion_tickets { get; set; }
        public virtual ICollection<comentarios>? comentarios { get; set; }
    }

    public class asignacion_tickets
    {
        [Key]
        public int id_asignacion { get; set; }

        public int id_ticket { get; set; }

        public int id_empleado { get; set; }

        [Required]
        public DateTime fecha_asignacion { get; set; }

        [ForeignKey(nameof(id_ticket))]
        public virtual tickets tickets { get; set; }

        [ForeignKey(nameof(id_empleado))]
        public virtual empleados empleados { get; set; }
    }

    public class comentarios
    {
        [Key]
        public int id_comentario { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string comentario_texto { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string estado { get; set; }

        [Required]
        public DateTime fecha_asignacion { get; set; }

        public int id_ticket { get; set; }

        [ForeignKey(nameof(id_ticket))]
        public virtual tickets tickets { get; set; }

        public virtual ICollection<archivos_comentarios>? archivos_comentarios { get; set; }
    }

    public class archivos_comentarios
    {
        [Key]
        public int id_archivo { get; set; }

        public int id_comentario { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? nombre_archivo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? tipo_archivo { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? ruta_archivo { get; set; }

        public DateTime? fecha_subida { get; set; }

        [ForeignKey(nameof(id_comentario))]
        public virtual comentarios comentarios { get; set; }
    }
}
