using Primavera.Extensibility.Base.Editors;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaEntidadesAssociarIdioma.Base
{
    public class UiFichaFornecedores : FichaFornecedores
    {
        // acrescenta o código do idioma à ficha de terceiro (de acordo com o pais), quando se usa a funcionalidade criar novo terceiro através dos serviços Primavera Cloud
        public override void AntesDeGravar(ref bool Cancel, ExtensibilityEventArgs e)
        {
            if (this.Fornecedor.EmModoEdicao == false && string.IsNullOrWhiteSpace(this.Fornecedor.Idioma))
            {
                string pais;
                pais = this.Fornecedor.Pais;

                this.Fornecedor.UtilizaIdioma = true;
                this.Fornecedor.Idioma = BSO.Base.Paises.DaValorAtributo(pais, "Idioma");
            }
        }
    }
}
