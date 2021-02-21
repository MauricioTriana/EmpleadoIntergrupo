export class Empleado {
    IdEmpleado!: number;
    NombreEmpleado!: string;
    ApellidoEmpleado!: string;
    DocumentoIdentidad!: string;
    Cargo!: string;
    contrasena!: string;

    constructor(
        IdEmpleado: number,
        NombreEmpleado: string,
        ApellidoEmpleado: string,
        DocumentoIdentidad: string,
        Cargo: string,
        contrasena: string
    ) {
        this.IdEmpleado = IdEmpleado;
        this.NombreEmpleado = NombreEmpleado;
        this.ApellidoEmpleado = ApellidoEmpleado;
        this.DocumentoIdentidad = DocumentoIdentidad;
        this.Cargo = Cargo;
        this.contrasena = contrasena;
    }
}