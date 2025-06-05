using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIS_Ticket_daw.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categorias_servicios",
                columns: table => new
                {
                    id_categoria_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias_servicios", x => x.id_categoria_servicio);
                });

            migrationBuilder.CreateTable(
                name: "Categorias_tickets",
                columns: table => new
                {
                    id_categoria_ticket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_tickets", x => x.id_categoria_ticket);
                });

            migrationBuilder.CreateTable(
                name: "estado_servicios",
                columns: table => new
                {
                    id_estado_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_servicios", x => x.id_estado_servicio);
                });

            migrationBuilder.CreateTable(
                name: "estado_tickets",
                columns: table => new
                {
                    id_estado_ticket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_tickets", x => x.id_estado_ticket);
                });

            migrationBuilder.CreateTable(
                name: "prioridades_tickets",
                columns: table => new
                {
                    id_prioridad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nivel_prioridad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prioridades_tickets", x => x.id_prioridad);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_rol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion_rol = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    correo_electronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    id_empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.id_empleado);
                    table.ForeignKey(
                        name: "FK_empleados_roles_id_rol",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id_rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleados_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicio_cliente",
                columns: table => new
                {
                    id_servicio_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    nombre_del_problema = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    descripcion_del_problema = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    fecha_del_probelma = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio_cliente", x => x.id_servicio_cliente);
                    table.ForeignKey(
                        name: "FK_servicio_cliente_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    id_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_servicio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    id_categoria_servicio = table.Column<int>(type: "int", nullable: false),
                    id_estado_servicio = table.Column<int>(type: "int", nullable: false),
                    id_servicio_cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.id_servicio);
                    table.ForeignKey(
                        name: "FK_servicios_categorias_servicios_id_categoria_servicio",
                        column: x => x.id_categoria_servicio,
                        principalTable: "categorias_servicios",
                        principalColumn: "id_categoria_servicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicios_estado_servicios_id_estado_servicio",
                        column: x => x.id_estado_servicio,
                        principalTable: "estado_servicios",
                        principalColumn: "id_estado_servicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicios_servicio_cliente_id_servicio_cliente",
                        column: x => x.id_servicio_cliente,
                        principalTable: "servicio_cliente",
                        principalColumn: "id_servicio_cliente");
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id_ticket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_cierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_categoria_ticket = table.Column<int>(type: "int", nullable: false),
                    id_estado_ticket = table.Column<int>(type: "int", nullable: false),
                    id_prioridad = table.Column<int>(type: "int", nullable: false),
                    id_servicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id_ticket);
                    table.ForeignKey(
                        name: "FK_tickets_Categorias_tickets_id_categoria_ticket",
                        column: x => x.id_categoria_ticket,
                        principalTable: "Categorias_tickets",
                        principalColumn: "id_categoria_ticket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_estado_tickets_id_estado_ticket",
                        column: x => x.id_estado_ticket,
                        principalTable: "estado_tickets",
                        principalColumn: "id_estado_ticket",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_prioridades_tickets_id_prioridad",
                        column: x => x.id_prioridad,
                        principalTable: "prioridades_tickets",
                        principalColumn: "id_prioridad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_servicios_id_servicio",
                        column: x => x.id_servicio,
                        principalTable: "servicios",
                        principalColumn: "id_servicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tickets_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asignacion_tickets",
                columns: table => new
                {
                    id_asignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_ticket = table.Column<int>(type: "int", nullable: false),
                    id_empleado = table.Column<int>(type: "int", nullable: false),
                    fecha_asignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignacion_tickets", x => x.id_asignacion);
                    table.ForeignKey(
                        name: "FK_asignacion_tickets_empleados_id_empleado",
                        column: x => x.id_empleado,
                        principalTable: "empleados",
                        principalColumn: "id_empleado",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_asignacion_tickets_tickets_id_ticket",
                        column: x => x.id_ticket,
                        principalTable: "tickets",
                        principalColumn: "id_ticket",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    id_comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comentario_texto = table.Column<string>(type: "varchar(300)", nullable: false),
                    estado = table.Column<string>(type: "varchar(200)", nullable: false),
                    fecha_asignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_ticket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.id_comentario);
                    table.ForeignKey(
                        name: "FK_comentarios_tickets_id_ticket",
                        column: x => x.id_ticket,
                        principalTable: "tickets",
                        principalColumn: "id_ticket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "archivos_comentarios",
                columns: table => new
                {
                    id_archivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_comentario = table.Column<int>(type: "int", nullable: false),
                    nombre_archivo = table.Column<string>(type: "varchar(255)", nullable: true),
                    tipo_archivo = table.Column<string>(type: "varchar(200)", nullable: true),
                    ruta_archivo = table.Column<string>(type: "varchar(300)", nullable: true),
                    fecha_subida = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archivos_comentarios", x => x.id_archivo);
                    table.ForeignKey(
                        name: "FK_archivos_comentarios_comentarios_id_comentario",
                        column: x => x.id_comentario,
                        principalTable: "comentarios",
                        principalColumn: "id_comentario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_archivos_comentarios_id_comentario",
                table: "archivos_comentarios",
                column: "id_comentario");

            migrationBuilder.CreateIndex(
                name: "IX_asignacion_tickets_id_empleado",
                table: "asignacion_tickets",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "IX_asignacion_tickets_id_ticket",
                table: "asignacion_tickets",
                column: "id_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_id_ticket",
                table: "comentarios",
                column: "id_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_id_rol",
                table: "empleados",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_id_usuario",
                table: "empleados",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_cliente_id_usuario",
                table: "servicio_cliente",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_id_categoria_servicio",
                table: "servicios",
                column: "id_categoria_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_id_estado_servicio",
                table: "servicios",
                column: "id_estado_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_id_servicio_cliente",
                table: "servicios",
                column: "id_servicio_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_categoria_ticket",
                table: "tickets",
                column: "id_categoria_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_estado_ticket",
                table: "tickets",
                column: "id_estado_ticket");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_prioridad",
                table: "tickets",
                column: "id_prioridad");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_servicio",
                table: "tickets",
                column: "id_servicio");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_id_usuario",
                table: "tickets",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "archivos_comentarios");

            migrationBuilder.DropTable(
                name: "asignacion_tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "Categorias_tickets");

            migrationBuilder.DropTable(
                name: "estado_tickets");

            migrationBuilder.DropTable(
                name: "prioridades_tickets");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "categorias_servicios");

            migrationBuilder.DropTable(
                name: "estado_servicios");

            migrationBuilder.DropTable(
                name: "servicio_cliente");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
