﻿using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopAdministrativo
{
    public partial class TelaComprasAcompanhamento : Form
    {
        //Instancia os objetos dos controle
        Panel panelMenus = new Panel();
        Button btnMenuCompras = new Button();
        Button btnMenuConsultas = new Button();
        Button btnMenuEstoque = new Button();
        Button btnMenuOrdemDeProducao = new Button();
        Button btnMenuPessoasECredores = new Button();

        private float vezesBtnMenuClicado = 0;

        public TelaComprasAcompanhamento(string nomeFuncionario)
        {
            InitializeComponent();
            pictureTop.Width = int.MaxValue;
            this.nomeFuncionario = nomeFuncionario;
            labelNomeFuncionario.Text = "Olá, " + nomeFuncionario;
            //GerarLabelsClientes();
            ConsultarBancoDadosEExibirResultados();

        }
        //Método que mostra um MessageBox perguntando se deseja fechar ou não o programa
        public void FecharPrograma()
        {
            DialogResult result = MessageBox.Show("Deseja fechar o programa Morangolandia?", "s a i r", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                //Desloga da conta e fecha o programa
                Close();
            }
        }
        //Métódo usado para saber que um form foi aberto
        private Form FormJaAberto(Type formType)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == formType)
                {
                    return openForm;
                }
            }
            return null;
        }
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //MANIPULAÇÃO DO MENU
        //Método para abrir menu lateral
        private void ExibirMenu()
        {
            vezesBtnMenuClicado++;
            //Adiciona o controle panel para ser fundo do menu e o exibe
            Controls.Add(panelMenus);
            panelMenus.Show();
            pictureTop.SendToBack();
            pictureTop.Width = int.MaxValue;
            panelMenus.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            panelMenus.Visible = true;
            panelMenus.BackColor = Color.FromArgb(221, 139, 249);
            panelMenus.Location = new Point(0 - 2);
            panelMenus.Width = 284;
            panelMenus.Height = int.MaxValue;
            panelMenus.AutoSize = true;
            panelMenus.BringToFront();
            pictureLogoMorangolandia.Location = new Point(309, 3);
            btnMenu.BackColor = Color.FromArgb(221, 139, 249);
            btnMenu.BringToFront();

            //Adiciona o controle botão
            Controls.Add(btnMenuCompras);
            Controls.Add(btnMenuEstoque);
            Controls.Add(btnMenuOrdemDeProducao);
            Controls.Add(btnMenuPessoasECredores);
            //Coloca os botões e panel para a frente
            btnMenuCompras.BringToFront();
            btnMenuEstoque.BringToFront();
            btnMenuOrdemDeProducao.BringToFront();
            btnMenuPessoasECredores.BringToFront();
            //Escolhe cursor "Hand" para interação com o mouse
            btnMenuCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMenuEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMenuOrdemDeProducao.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMenuPessoasECredores.Cursor = System.Windows.Forms.Cursors.Hand;
            //Escolhe a posição que o botão irá ficar
            btnMenuCompras.Location = new Point(33, 158);
            btnMenuEstoque.Location = new Point(33, 227);
            btnMenuOrdemDeProducao.Location = new Point(33, 296);
            btnMenuPessoasECredores.Location = new Point(33, 365);
            //Torna a visibilidade do botão verdadeira
            btnMenuCompras.Visible = true;
            btnMenuEstoque.Visible = true;
            btnMenuOrdemDeProducao.Visible = true;
            btnMenuPessoasECredores.Visible = true;
            //Escolhe a fonte utilizada para o nome no botão
            btnMenuCompras.Font = new Font("Franklin Gothic Heavy", (float)15.75);
            btnMenuEstoque.Font = new Font("Franklin Gothic Heavy", (float)15.75);
            btnMenuOrdemDeProducao.Font = new Font("Franklin Gothic Heavy", (float)15.75);
            btnMenuPessoasECredores.Font = new Font("Franklin Gothic Heavy", (float)15.75);
            //Escolhe a cor da fonte do botão
            btnMenuCompras.ForeColor = Color.White;
            btnMenuEstoque.ForeColor = Color.White;
            btnMenuOrdemDeProducao.ForeColor = Color.White;
            btnMenuPessoasECredores.ForeColor = Color.White;
            //Escolhe a cor de fundo do botão
            btnMenuCompras.BackColor = Color.FromArgb(221, 139, 249);
            btnMenuEstoque.BackColor = Color.FromArgb(221, 139, 249);
            btnMenuOrdemDeProducao.BackColor = Color.FromArgb(221, 139, 249);
            btnMenuPessoasECredores.BackColor = Color.FromArgb(221, 139, 249);
            //Ancora o botão á direita superior da tela
            btnMenuCompras.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnMenuEstoque.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnMenuOrdemDeProducao.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnMenuPessoasECredores.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            //Redimenciona o botão automaticamente
            btnMenuCompras.AutoSize = true;
            btnMenuEstoque.AutoSize = true;
            btnMenuOrdemDeProducao.AutoSize = true;
            btnMenuPessoasECredores.AutoSize = true;
            //Indica se o controle pode interagir com o usuário
            btnMenuCompras.Enabled = true;
            btnMenuEstoque.Enabled = true;
            btnMenuOrdemDeProducao.Enabled = true;
            btnMenuPessoasECredores.Enabled = true;
            //Escolhe o estilo do botão
            btnMenuCompras.FlatStyle = FlatStyle.Flat;
            btnMenuEstoque.FlatStyle = FlatStyle.Flat;
            btnMenuOrdemDeProducao.FlatStyle = FlatStyle.Flat;
            btnMenuPessoasECredores.FlatStyle = FlatStyle.Flat;
            //Tira a borda do botão
            btnMenuCompras.FlatAppearance.BorderSize = 0;
            btnMenuEstoque.FlatAppearance.BorderSize = 0;
            btnMenuOrdemDeProducao.FlatAppearance.BorderSize = 0;
            btnMenuPessoasECredores.FlatAppearance.BorderSize = 0;
            //Escolhe a cor de fundo do botão ao deixar o mouse dentro dos limites do botão
            btnMenuCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(221, 139, 249);
            btnMenuEstoque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(221, 139, 249);
            btnMenuOrdemDeProducao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(221, 139, 249);
            btnMenuPessoasECredores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(221, 139, 249);
            //Instancia o evento de interação quando o mouse passa por cima do botão
            btnMenuCompras.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMenuCompras_MouseMove);
            btnMenuEstoque.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMenuEstoque_MouseMove);
            btnMenuOrdemDeProducao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMenuOrdemDeProducao_MouseMove);
            btnMenuPessoasECredores.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMenuPessoasECredores_MouseMove);
            //Instancia o evento de interação quando o mouse sai de cima do botão
            btnMenuCompras.MouseLeave += new System.EventHandler(this.btnMenuCompras_MouseLeave);
            btnMenuEstoque.MouseLeave += new System.EventHandler(this.btnMenuEstoque_MouseLeave);
            btnMenuOrdemDeProducao.MouseLeave += new System.EventHandler(this.btnMenuOrdemDeProducao_MouseLeave);
            btnMenuPessoasECredores.MouseLeave += new System.EventHandler(this.btnMenuPessoasECredores_MouseLeave);
            //Instancia o evento de interação quando o usuário clica com o mouse no botão
            btnMenuCompras.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMenuCompras_Click);
            btnMenuEstoque.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMenuEstoque_Click);
            btnMenuOrdemDeProducao.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMenuOrdemDeProducao_Click);
            btnMenuPessoasECredores.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMenuPessoasECredores_Click);
            //Define o texto exibido no botão
            btnMenuCompras.Text = "Compras";
            btnMenuEstoque.Text = "Estoque";
            btnMenuOrdemDeProducao.Text = "Ordem de Produção";
            btnMenuPessoasECredores.Text = "Pessoas e Credores";
        }
        //Método para "fechar"(ocultar) menu lateral
        private void OcultarMenu()
        {
            vezesBtnMenuClicado++;
            Controls.Add(panelMenus);
            panelMenus.Hide();
            pictureLogoMorangolandia.Location = new Point(118, 3);
            btnMenu.BackColor = Color.FromArgb(162, 66, 195);
            btnMenuCompras.Visible = false;
            btnMenuEstoque.Visible = false;
            btnMenuOrdemDeProducao.Visible = false;
            btnMenuPessoasECredores.Visible = false;
        }
        //Evento de click no botão "MENU"
        private void btnMenu_MouseClick(object sender, MouseEventArgs e)
        {
            //Se a quantidade de click for par, abre o menu
            //Se a quantidade de click for impar, fecha o menu
            if (vezesBtnMenuClicado % 2 == 0)
            {
                ExibirMenu();
            }
            else
            {
                OcultarMenu();
            }
        }
        //CONFIRMAÇÃO DE BOTÕES DO MENU:
        //MouseMove: evento de interação quando o mouse passa por cima do botão
        //MouseLeave: evento de interação quando o mouse passa por cima do botão
        private void btnMenuCompras_MouseMove(object sender, MouseEventArgs e)
        {
            //Adiciona sublinhado ao texto do botão
            btnMenuCompras.Font = new Font("Franklin Gothic Heavy", (float)15.75, FontStyle.Underline);
        }
        private void btnMenuCompras_MouseLeave(object sender, EventArgs e)
        {
            //"Retira" sublianhado do botão
            btnMenuCompras.Font = new Font("Franklin Gothic Heavy", (float)15.75);
        }
        private void btnMenuEstoque_MouseMove(object sender, MouseEventArgs e)
        {
            btnMenuEstoque.Font = new Font("Franklin Gothic Heavy", (float)15.75, FontStyle.Underline);
        }
        private void btnMenuEstoque_MouseLeave(object sender, EventArgs e)
        {
            btnMenuEstoque.Font = new Font("Franklin Gothic Heavy", (float)15.75);
        }
        private void btnMenuOrdemDeProducao_MouseMove(object sender, MouseEventArgs e)
        {
            btnMenuOrdemDeProducao.Font = new Font("Franklin Gothic Heavy", (float)15.75, FontStyle.Underline);
        }
        private void btnMenuOrdemDeProducao_MouseLeave(object sender, EventArgs e)
        {
            btnMenuOrdemDeProducao.Font = new Font("Franklin Gothic Heavy", (float)15.75);
        }
        private void btnMenuPessoasECredores_MouseMove(object sender, MouseEventArgs e)
        {
            btnMenuPessoasECredores.Font = new Font("Franklin Gothic Heavy", (float)15.75, FontStyle.Underline);
        }
        private void btnMenuPessoasECredores_MouseLeave(object sender, EventArgs e)
        {
            btnMenuPessoasECredores.Font = new Font("Franklin Gothic Heavy", (float)15.75);
        }
        //Eventos de click do mouse em botões do menu
        private void btnMenuCompras_Click(object sender, EventArgs e)
        {
            //Oculta o menu lateral e seta o valor 0 a variável "vezesBtnMenuClicado"
            //Fazendo com que a contagem reinicie e o menu possa ser aberto novamente
            OcultarMenu();
            vezesBtnMenuClicado = 0;
            //Abre tela "Compras" e fecha a atual
            TelaComprasAcompanhamento tela = new TelaComprasAcompanhamento(nomeFuncionario);
            tela.Show();
            Close();
        }
        private void btnMenuEstoque_Click(object sender, EventArgs e)
        {
            //Abre tela "Estoque de Insumos" e fecha a atual
            TelaEstoque tela = new TelaEstoque(nomeFuncionario);
            tela.Show();
            Close();
        }
        private void btnMenuOrdemDeProducao_Click(object sender, EventArgs e)
        {
            //Abre tela "Ordem de Produção" e fecha a atual
            TelaOrdemDeProducao tela = new TelaOrdemDeProducao(nomeFuncionario);
            tela.Show();
        }
        private void btnMenuPessoasECredores_Click(object sender, EventArgs e)
        {
            //Abre tela "Pessoas e Credores" e fecha a atual
            TelaPessoasECredoresConsulta tela = new TelaPessoasECredoresConsulta(nomeFuncionario);
            tela.Show();
        }
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //Evento de click do mouse em botão "Esc"
        private void btnEsc_Click(object sender, EventArgs e)
        {
            FecharPrograma();
        }
        //Evento que ativa a interação do teclado com a tela
        private void TelaComprasAcompanhamento_KeyDown(object sender, KeyEventArgs e)
        {
            //Responsável por fechar tela atual e abrir a anterior
            if (e.KeyData == Keys.Escape)
            {
                FecharPrograma();
            }
        }
        //Ao clicar na tela com o Menu aberto, fecha o menu
        private void TelaComprasAcompanhamento_MouseClick(object sender, MouseEventArgs e)
        {
            if (vezesBtnMenuClicado % 2 != 0)
            {
                OcultarMenu();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //Abre tela "ComprasNovaCompra" e fecha a atual
            TelaComprasNovaCompra telaCompra = new TelaComprasNovaCompra(nomeFuncionario);
            telaCompra.Show();
            Close();
        }
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //--------------------------------------BANCO DE DADOS------------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        private string SqlStringDeConexao = @"Data Source=CYBERLOGRA\SQLSERVER2022;Initial Catalog=DBMorangolandia;Integrated Security=True";
        private string nomeFuncionario;
        private string codigoNotaFiscal, numNotaFiscal, statusCompra, nomeFornecedor;
        private DateTime dataEmissao;
        private float valorUnitario;

        //private void lerBD(string query, SqlConnection connection, List<string> valoresImportados, string coluna)
        //{
        //    using (SqlCommand command = new SqlCommand(query, connection))
        //    {
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            // Ler os dados linha a linha e adicionar à lista
        //            while (reader.Read())
        //            {
        //                valoresImportados.Add(reader[coluna].ToString());
        //            }
        //        }
        //    }
        //}
        //private void GerarLabelsDeConsulta(List<string> valores, string nomeValores, TableLayoutPanel tablePanel)
        //{
        //    int row = 1; // Começamos a partir da segunda linha, pois a primeira será para os cabeçalhos
        //    foreach (string nome in valores)
        //    {
        //        Label labelExibicao = new Label();

        //        // Formatação condicional do texto
        //        if (nomeValores == "valoresCompras")
        //        {
        //            labelExibicao.Text = "R$ " + nome;
        //        }
        //        else if (nomeValores == "datasDeEmissao")
        //        {
        //            DateTime data = DateTime.Parse(nome);
        //            labelExibicao.Text = data.ToString("dd/MM/yyyy");
        //        }
        //        else
        //        {
        //            labelExibicao.Text = nome;
        //        }

        //        // Ajustar a aparência do label
        //        labelExibicao.AutoSize = true;
        //        labelExibicao.Font = new Font("Arial", 14);  // Tamanho maior para melhor visualização
        //        labelExibicao.ForeColor = Color.Black;
        //        labelExibicao.BackColor = Color.FromArgb(247, 223, 255);  // Fundo suave
        //        labelExibicao.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        //        labelExibicao.TextAlign = ContentAlignment.MiddleCenter;
        //        labelExibicao.Padding = new Padding(10);  // Adiciona espaçamento interno

        //        // Adicionando o label à linha da tabela
        //        tablePanel.Controls.Add(labelExibicao, tablePanel.ColumnCount - 1, row); // Coloca na última coluna
        //        row++; // Incrementa a linha
        //    }
        //}

        //private void GerarLabelsClientes()
        //{
        //    // Consulta SQL otimizada com JOIN
        //    string query = @"SELECT cod_compra, nf, dt_emissao, nome_fant, valor_unit, status_compras  FROM TBCompras JOIN TBFornecedor ON TBCompras.fk_forn = TBFornecedor.id_forn";

        //    // Listas para armazenar os dados
        //    List<string> codigosCompras = new List<string>();
        //    List<string> numerosNotasFiscais = new List<string>();
        //    List<string> datasDeEmissao = new List<string>();
        //    List<string> nomesFornecedor = new List<string>();
        //   // List<string> valoresCompras = new List<string>();
        //    List<string> statusCompras = new List<string>();

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(SqlStringDeConexao))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(query, connection);
        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                codigosCompras.Add(reader["cod_compra"].ToString());
        //                numerosNotasFiscais.Add(reader["nf"].ToString());
        //                datasDeEmissao.Add(reader["dt_emissao"].ToString());
        //                nomesFornecedor.Add(reader["nome_fant"].ToString());
        //               // valoresCompras.Add(reader["valor_unit"].ToString());
        //                statusCompras.Add(reader["status_compras"].ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
        //        return;
        //    }

        //    // Criar o TableLayoutPanel para a organização dos dados
        //    TableLayoutPanel tablePanel = new TableLayoutPanel();
        //    tablePanel.Location = new System.Drawing.Point(40, 140);  // Posição inicial
        //    tablePanel.Size = new System.Drawing.Size(this.Width - 80, this.Height - 180);  // Preenche a tela
        //    tablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;  // Ajuste para crescer
        //    tablePanel.BackColor = Color.FromArgb(252, 251, 231);
        //    tablePanel.ColumnCount = 6;  // Uma coluna para cada campo
        //    tablePanel.RowCount = codigosCompras.Count + 1;  // Uma linha extra para os cabeçalhos
        //    tablePanel.AutoSize = true;
        //    tablePanel.ColumnStyles.Clear();

        //    // Definir os cabeçalhos da tabela
        //    tablePanel.Controls.Add(new Label() { Text = "Código Compra", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 0, 0);
        //    tablePanel.Controls.Add(new Label() { Text = "Nota Fiscal", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 1, 0);
        //    tablePanel.Controls.Add(new Label() { Text = "Data Emissão", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 2, 0);
        //    tablePanel.Controls.Add(new Label() { Text = "Fornecedor", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 3, 0);
        //    //tablePanel.Controls.Add(new Label() { Text = "Valor Unitário", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 4, 0);
        //    tablePanel.Controls.Add(new Label() { Text = "Status", Font = new Font("Arial", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter }, 5, 0);

        //    // Ajuste das larguras das colunas
        //    for (int i = 0; i < tablePanel.ColumnCount; i++)
        //    {
        //        tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66f)); // Coloca cada coluna com tamanho proporcional
        //    }

        //    // Gerar as linhas de dados
        //    for (int i = 0; i < codigosCompras.Count; i++)
        //    {
        //        tablePanel.Controls.Add(new Label() { Text = codigosCompras[i], Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 0, i + 1);
        //        tablePanel.Controls.Add(new Label() { Text = numerosNotasFiscais[i], Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 1, i + 1);
        //        tablePanel.Controls.Add(new Label() { Text = DateTime.Parse(datasDeEmissao[i]).ToString("dd/MM/yyyy"), Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 2, i + 1);
        //        tablePanel.Controls.Add(new Label() { Text = nomesFornecedor[i], Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 3, i + 1);
        //       // tablePanel.Controls.Add(new Label() { Text = "R$ " + valoresCompras[i], Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 4, i + 1);
        //        tablePanel.Controls.Add(new Label() { Text = statusCompras[i], Font = new Font("Arial", 12), TextAlign = ContentAlignment.MiddleCenter }, 5, i + 1);
        //    }

        //    // Adicionar o painel com os dados ao formulário
        //    this.Controls.Add(tablePanel);
        //}

        /// <summary>
        /// /////////////////////////
        /// </summary>
        private void ConsultarBancoDadosEExibirResultados()
        {
            using (SqlConnection conn = new SqlConnection(SqlStringDeConexao))
            {
                try
                {
                    conn.Open();

                    // Inicia a consulta básica sem filtros
                    string query = @"SELECT cod_compra, nf, dt_emissao, nome_fant, valor_unit, status_compras  FROM TBCompras JOIN TBFornecedor ON TBCompras.fk_forn = TBFornecedor.id_forn";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        CriarComponentesDinamicos(reader); // Cria os componentes gráficos com os resultados
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao consultar o banco: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Cria os painéis e labels dinamicamente com base nos dados retornados do banco.
        /// </summary>
        private void CriarComponentesDinamicos(SqlDataReader reader)
        {
            int yOffset = 0; // Controle da posição vertical

            while (reader.Read())
            {
                // Criar o painel principal
                Panel panel = new Panel
                {
                    Size = new Size(920, 50),
                    BackColor = Color.LavenderBlush,
                    Location = new Point(200, yOffset),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Criar labels para as informações
                Label codigosCompras = new Label
                {
                    Text = $"Código Compra\n {reader["cod_compra"]}",
                    Location = new Point(10, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true
                };

                Label numerosNotasFiscais = new Label
                {
                    Text = $"Nota Fiscal\n{reader["nf"]}",
                    Location = new Point(200, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label nomesFornecedor = new Label
                {
                    Text = $"Fornecedor\n{reader["nome_fant"]}",
                    Location = new Point(320, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label datasDeEmissao = new Label
                {
                    // Verifica se a data é válida (não nula) e formata
                    Text = reader["dt_emissao"] != DBNull.Value ?
                           $"Data\n {Convert.ToDateTime(reader["dt_emissao"]).ToString("dd/MM/yyyy")}" :
                           "Data\n Não disponível",
                    Location = new Point(500, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label statusCompras = new Label
                {
                    Text = $"Status\n {reader["status_compras"]}",
                    Location = new Point(600, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };
                Label valorCompras = new Label
                {
                    Text = $"Valor\n R$ {reader["valor_unit"]}",
                    Location = new Point(700, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                // Adicionar os labels ao painel
                panel.Controls.Add(codigosCompras);
                panel.Controls.Add(numerosNotasFiscais);
                panel.Controls.Add(nomesFornecedor);
                panel.Controls.Add(datasDeEmissao);
                panel.Controls.Add(statusCompras);
                panel.Controls.Add(valorCompras);

                // Adicionar o painel ao painel principal
                panelResultado.Controls.Add(panel);

                // Incrementar a posição vertical para o próximo painel
                yOffset += 60;
            }
            // Após adicionar todos os painéis, ajustar a altura do panelResultado
            panelResultado.AutoScroll = true;  // Habilita a rolagem
            panelResultado.VerticalScroll.Value = 0; // Define o valor inicial da rolagem como 0
            panelResultado.AutoScrollMinSize = new Size(0, yOffset); // Ajusta a altura total com base no número de painéis
        }
    }
}
