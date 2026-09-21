using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using desalluno.Funciones;

// <<======================================================>>
// Token de cancelacion para DesallunoAsinc para poder cancelar la tarea si se tarda demasiado
using var ctsSin = new CancellationTokenSource();
ctsSin.CancelAfter(TimeSpan.FromMilliseconds(500));
// <<======================================================>>

Console.WriteLine("_____________________________________________________");
Console.WriteLine("=====================================================");
// <<======================================================>>
// Preparar el desayuno de manera Sincrona
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno
try
{
    await FuncionesSincronas.HacerDesalluno(ctsSin.Token);
}
catch (OperationCanceledException e)
{
    Console.WriteLine("¡El café se ha enfriado! Los huevos y tostadas con café frío no tienen gracia...");
}

Console.WriteLine("_____________________________________________________");

// <<======================================================>>
// Token de cancelacion para DesallunoAsinc para poder cancelar la tarea si se tarda demasiado
using var ctsAsin = new CancellationTokenSource();
ctsAsin.CancelAfter(TimeSpan.FromMilliseconds(500));
// <<======================================================>>

Console.WriteLine("=====================================================");
// <<======================================================>>
// Preparar el desayuno de manera Sincrona
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno
try
{
    await FuncionesAsincronas.HacerDesallunoAsinc(ctsAsin);
}
catch (OperationCanceledException e)
{
    Console.WriteLine("¡El café se ha enfriado! Los huevos y tostadas con café frío no tienen gracia...");
}
Console.WriteLine(".....................................................");

// <<======================================================>>
// Token de cancelacion para HacerDesallunoOptimo para poder cancelar la tarea si se tarda demasiado
using var ctsOpt = new CancellationTokenSource();
ctsOpt.CancelAfter(TimeSpan.FromMilliseconds(500));
// <<======================================================>>

Console.WriteLine("=====================================================");

// <<======================================================>>
// Preparar el desayuno de la manera mas optima
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno
try
{
    await FuncionesMasOptimas.HacerDesallunoOptimo(ctsOpt.Token);
}
catch (OperationCanceledException e)
{
    Console.WriteLine("¡El café se ha enfriado! Los huevos y tostadas con café frío no tienen gracia...");
}
Console.WriteLine(".....................................................");

// <<======================================================>>
//   ======================================================
// <<======================================================>>

//Ejecucion sin Tokens de cancelacion 

TimeSpan timeSinq ;
TimeSpan timeAsinq ;
TimeSpan timeOptima ;
// <<======================================================>>
// Token de cancelacion para DesallunoAsinc para poder cancelar la tarea si se tarda demasiado
using var ctsSin2 = new CancellationTokenSource();
// <<======================================================>>

Console.WriteLine("_____________________________________________________");
Console.WriteLine("=====================================================");
// <<======================================================>>
// Preparar el desayuno de manera Sincrona
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno

timeSinq = await FuncionesSincronas.HacerDesalluno(ctsSin2.Token);

Console.WriteLine("_____________________________________________________");

// <<======================================================>>
// Token de cancelacion para DesallunoAsinc para poder cancelar la tarea si se tarda demasiado
using var ctsAsin2 = new CancellationTokenSource();
// <<======================================================>>

Console.WriteLine("=====================================================");
// <<======================================================>>
// Preparar el desayuno de manera Sincrona
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno

timeAsinq = await FuncionesAsincronas.HacerDesallunoAsinc(ctsAsin2);

Console.WriteLine(".....................................................");

// <<======================================================>>
// Token de cancelacion para HacerDesallunoOptimo para poder cancelar la tarea si se tarda demasiado
using var ctsOpt2 = new CancellationTokenSource();
// <<======================================================>>

Console.WriteLine("=====================================================");

// <<======================================================>>
// Preparar el desayuno de la manera mas optima
// Capturamos la excepcion de cancelacion en caso de que se tarde demasiado en preparar el desayuno

timeOptima = await FuncionesMasOptimas.HacerDesallunoOptimo(ctsOpt2.Token);
// <<======================================================>>
// Comprobamos los tiempos de ejecucion de cada metodo
Console.WriteLine(".....................................................");
Console.WriteLine($"Tiempo total de preparación del desayuno (sincrono): {timeSinq} ms");
Console.WriteLine($"Tiempo total de preparación del desayuno (asincrono): {timeAsinq} ms");
Console.WriteLine($"Tiempo total de preparación del desayuno (optimo): {timeOptima} ms");

