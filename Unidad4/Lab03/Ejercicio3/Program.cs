using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            dsUniversidad miUniversidad = new dsUniversidad();

            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            //ALUMNOS
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();

            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            //CURSOS
            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();

            rowCurso.Curso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);

            //ALUMNOS_CURSOS
            dsUniversidad.dtAlumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dtAlumnos_CursosDataTable();
            dsUniversidad.dtAlumnos_CursosRow rowAlumnosCursos = dtAlumnos_Cursos.NewdtAlumnos_CursosRow();

            rowAlumnosCursos.IDAlumno = 0;
            rowAlumnosCursos.IDCurso = 1;

            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumnosCursos);

            //Otro ALUMNO
            rowAlumno = dtAlumnos.NewdtAlumnosRow();

            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Marcelo";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            Console.ReadKey();
        }
    }
}
