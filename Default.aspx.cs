using AVCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            publishDataset();
            publishIndice();
            pnlSuccess.Visible = true;
        }
        catch (Exception ex)
        {
            pnlError.Visible = true;
            lblException.Text = ex.ToString();
        }
    }

    private void publishIndice()
    {
        string path = Server.MapPath("/XML/index.xml");
        indici indice = new indici();
        indice.metadata = new indiciMetadata();
        indice.metadata.annoRiferimento = 2012;

        indice.indice = new List<indiciDataset>();

        indiciDataset link1 = new indiciDataset();
        link1.linkDataset = "/XML/dataset.xml";
        indice.indice.Add(link1);
        indice.indice.Add(link1);

        AVCPXMLWriter.WriteXMLFile<indici>(indice, path);
    }

    private void publishDataset()
    {
        // contenitore
        string path = Server.MapPath("/XML/dataset.xml");
        pubblicazione p = new pubblicazione();

        p.metadata = new pubblicazioneMetadata();
        p.metadata.titolo = "titolo";
        p.metadata.@abstract = "@abstract";
        p.metadata.dataPubbicazioneDataset = new AVCPDateTime();
        p.metadata.entePubblicatore = "ente";
        p.metadata.annoRiferimento = 2901;
        p.metadata.urlFile = "http://nomefile.xml";
        p.metadata.licenza = "licenza";

        // lista lotti della pubblicazione
        List<pubblicazioneLotto> lotti = new List<pubblicazioneLotto>();
        pubblicazioneLotto lotto1 = new pubblicazioneLotto();
        lotto1.cig = "cig";
        lotto1.strutturaProponente.codiceFiscaleProp = "scccrl82e24h501x";
        lotto1.strutturaProponente.denominazione = "denominazione proponente";
        lotto1.oggetto = "Test lotto";
        lotto1.sceltaContraente = sceltaContraenteType.Item01PROCEDURAAPERTA;
        lotto1.importoAggiudicazione = Convert.ToDecimal(Math.Round(10.325, 2));
        lotto1.importoSommeLiquidate = Convert.ToDecimal( Math.Round(10.325, 2)) ;
        lotti.Add(lotto1);
        p.data = lotti;

        // partecipanti
        lotto1.partecipanti = new pubblicazioneLottoPartecipanti();
        lotto1.partecipanti.partecipante = new List<singoloType>();

        // partecipanti - singolo
        singoloType partecipante = new singoloType();
        partecipante.identificativoFiscale = new codiceFiscaleType("scccrl82e24h501x");// "cf";
        partecipante.ragioneSociale = "azienda";
        lotto1.partecipanti.partecipante.Add(partecipante);

        // partecipanti - gruppo 1
        lotto1.partecipanti.Raggruppamenti = new List<pubblicazioneLottoRaggruppamento>();
        pubblicazioneLottoRaggruppamento gruppo1 = new pubblicazioneLottoRaggruppamento();
        gruppo1.Membri = new List<aggregatoType>();

        aggregatoType membro = new aggregatoType();
        membro.identificativoFiscale = new identificativoFiscaleEstero("123sonoestero");
        membro.ragioneSociale = "azienda straniera";
        membro.ruolo = ruoloType.Item01MANDANTE;
        gruppo1.Membri.Add(membro);

        aggregatoType membro2 = new aggregatoType();
        membro2.identificativoFiscale = new identificativoFiscaleEstero("123sonoestero 2");
        membro2.ragioneSociale = "azienda straniera 2";
        membro2.ruolo = ruoloType.Item02MANDATARIA;
        gruppo1.Membri.Add(membro2);

        lotto1.partecipanti.Raggruppamenti.Add(gruppo1);

        // aggiudicatari gruppo 1
        lotto1.aggiudicatari = new pubblicazioneLottoAggiudicatari();
        lotto1.aggiudicatari.aggiudicatario = new List<singoloType>();
        lotto1.aggiudicatari.Raggruppamenti = new List<pubblicazioneLottoRaggruppamento>();

        lotto1.aggiudicatari.aggiudicatario.Add(partecipante);
        lotto1.aggiudicatari.Raggruppamenti.Add(gruppo1);

        // tempi completamento
        lotto1.tempiCompletamento = new pubblicazioneLottoTempiCompletamento();
        lotto1.tempiCompletamento.dataInizio = new AVCPDateTime(DateTime.Now);
        lotto1.tempiCompletamento.dataUltimazione = new AVCPDateTime(DateTime.Now);



        AVCPXMLWriter.WriteXMLFile<pubblicazione>(p, path);
    }
}