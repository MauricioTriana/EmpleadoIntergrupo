namespace PlanesFamiliares.Helper
{
    public class Enumeraciones
    {
        public enum TiposSMS
        {
            TextoCodVerificacion,
            MensajeBienvenidaPadre,
            MensajeBienvenidaIntegrante,
            TextoCambioPlanPadre,
            TextoCambioPlanHijo,
            MensajeInscripAdministrador,
            SMSActivacionLider,
            SMSActivacionHija,
            SMSEliminacionIntegrante,
            SMSSuspencionComunidad,
            SMSRehabilitacionComunidad,
        }

        public enum Direccionamiento
        {
            ResumenPadre = 1,
            IngresarIntegrante = 2,
            Error = 3,
            PlanNoAplica = 4,
            EstadoNoActivo = 5,
            SegmentoNoAplica = 6,
            Suspendido = 7,
            BienvenidaHija = 8,
            AgregarComunidad = 9,
        }

        public enum TipoBono
        {
            Temporal = 1,
            Renovable = 2,
        }

        public enum TipoMensaje
        {
            ConsultaLineas = 1,
            Intentos = 2,
            ValidarOK = 3,
            ValidarNoOK = 4
        }

        public enum TipoAccionChangePrimary
        {
            Agregar = 1,
            Modificar = 2,

        }

        public enum MensajesUsuario
        {
            InicioTitulo = 020,
            InicioSubTitulo = 021,
            AdicionarLiderAceptarTerminos = 022,
            AdicionarLiderNombreDefectoLider = 023,
            AdicionarLiderMensajeBienvenida = 024,
            AdicionarLiderGigasDisponibles = 025,
            AdicionarLiderMensajeProceso = 026,
            AdicionarLiderIngresarNombre = 027,
            AdicionarLiderErrorTerminos = 028,
            PantallaErrorErrorSinOferta = 029,
            PantallaErrorSinOfertaInformacion = 030,
            PantallaExitoComunidadBienvenidaTitulo = 031,
            PantallaExitoComunidadBienvenidaMensaje = 032,
            PantallaResumenMensajeGigas = 033,
            PantallaErrorValidarEstadoSuspendidoTitulo = 034,
            PantallaErrorValidarEstadoSuspendidoSubTitulo = 035,
            PantallaErrorValidarSegmentoTitulo = 036,
            PantallaErrorValidarSegmentoSubTitulo = 037,
            PantallaErrorValidarPlanFamiliarTitulo = 038,
            PantallaErrorValidarPlanFamiliarSubtitulo = 039,
            PantallaErrorValidarEstadoTitulo = 040,
            PantallaErrorValidarEstadoSubtitulo = 041,
            PantallaErrorValidarOtraComunidadTitulo = 042,
            PantallaErrorValidarOtraComunidadSubtitulo = 043,
            PantallaErrorValidarBajaProgramadaTitulo = 044,
            PantallaErrorValidarBajaProgramadaSubtitulo = 045,
            PantallaErrorValidarPortabilidadProgramadaTitulo = 046,
            PantallaErrorValidarPortabilidadProgramadaSubtitulo = 047,
            PantallaErrorValidarAntiguedadTitulo = 048,
            PantallaErrorValidarAntiguedadSubtitulo = 049,
            PantallaErrorValidarCambioPosPreTitulo = 050,
            PantallaErrorValidarCambioPosPreSubtitulo = 051,
            PantallaErrorValidarCambioPrePostTitulo = 052,
            PantallaErrorValidarCambioPrePostSubtitulo = 053,
            PantallaErrorValidarCambioSIMTitulo = 054,
            PantallaErrorValidarCambioSIMSubtitulo = 055,
            PantallaErrorValidarCambioTitularidadTitulo = 056,
            PantallaErrorValidarCambioTitularidadSubtitulo = 057,
            PantallaErrorValidarMaximoLineasTitulo = 058,
            PantallaErrorValidarMaximoLineasSubtitulo = 059,
            PantallaErrorValidarSegmentoTituloHija = 060,
            PantallaErrorValidarSegmentoSubtituloHija = 061,
            PantallaErrorGeneralTitulo = 062,
            PantallaErrorGeneralSubtitulo = 063,
            PantallaErrorValidarCambioPlanProgramadoTitulo = 064,
            PantallaErrorValidarCambioPlanProgramadoSubtitulo = 065,
            AgregarComunidadCorte = 066,
            AgregarComunidadProceso = 067,
            PantallaErrorValidarPortOut = 068,
            PantallaExitoComunidadBienvenidaHijaMensaje = 69,
            PantallaErrorTransaccionTitulo = 071,
            PantallaErrorTransaccionSubtitulo = 072,
            MensajeHeader = 073,
            PantallaErrorLineaPrepagoLiderTitulo = 074,
            PantallaErrorLineaPrepagoLiderSubtitulo = 075,
            PantallaErrorDistribucionTituloIncorrecta = 076,
            PantallaErrorDistribucionSubTituloIncorrecta = 077,
            PantallaErrorDistribucionEnVacio = 078,
            PantallaErrorTituloValidacionCarteraFraude = 079,
            PantallaErrorSubTituloValidacionCarteraFraude = 080,
            PantallaErrorTituloValidacionNumeroLineasPosPago = 081,
            PantallaErrorSubTituloValidacionNumeroLineasPosPago = 082,
            PantallaErrorDistribucionSolicitudFinalizada = 085,
            PantallaErrorTituloMantenimiento = 086,
            PantallaErrorTituloLineaNoMovistar = 087,
            PantallaErrorSubTituloLineaNoMovistar = 088,
            PantallaErrorIngresoGeneralTitulo = 089,
            PantallaErrorIngresoGeneralSubtitulo = 090,
            PantallaErrorMoraTitulo = 095,
            PantallaErrorMoraSubtituloSinDato = 096,
            PantallaErrorMoraSubtituloCedula = 097
        }

        public enum TipoLinea
        {
            Prepago = 0,
            Pospago = 1,
            Portado,
            NoMovistar
        }

        public enum Medida
        {
            Bytes,
            KB,
            MB,
            GB,
            TB,
            PB
        }

        public enum TipoMensajeServicio
        {
            OK = 0,
            NOOK = 1
        }

        public enum EstadoIntegrante
        {
            Activo = 1,
            MoraLider = 4,
            Robo = 5,
            Fraude = 6,
            Baja = 7,
            APC = 8,
            MoraHija = 9,
            EnProceso = 99,
            FinalizadaDistribuir = 98
        }

        public enum EstadoCambioPlan
        {
            MigracionPendiente = 1,
            CambioPlanPendiente = 2,
            OrdenNoEncontrada = 3,
            CambioPlanActivo = 0,
            SinCambioPlan = 4,
            ErrorQueryOrden = 5
        }

        public enum LimitesSMS
        {
            CantidadLimiteCaracateres = 139
        }

        public enum TipoEjecucionContError
        { 
            Informativo,
            Excepcion
        }

        public enum MomentoEjecucionContError
        {
            RegistroPadre,
            RegistroHijo,
            Distribucion,
            EliminacionHijo,
            OpcionVideo
        }

        public enum ConversionGigasBytes
        {
            Giga = 1073741824
        }
    }
}
