﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DesktopAdministrativo.TelaComprasNovaCompra;

namespace DesktopAdministrativo
{
    public partial class TelaEstoque : Form
    {
        //Instancia os objetos dos controle
        Panel panelMenus = new Panel();
        Button btnMenuCompras = new Button();
        Button btnMenuConsultas = new Button();
        Button btnMenuEstoque = new Button();
        Button btnMenuOrdemDeProducao = new Button();
        Button btnMenuPessoasECredores = new Button();

        private int vezesBtnMenuClicado = 0;
        public TelaEstoque(string nomeFuncionario)
        {
            InitializeComponent();
            pictureTop.Width = int.MaxValue;
            this.nomeFuncionario = nomeFuncionario;
            labelNomeFuncionario.Text = "Olá, " + nomeFuncionario;
            CarregarTodosOsDados();
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
        //Método usado para abrir um form qualquer
        private void AbrirForm<ClasseQualquer>(bool fecharFormAtual = true) where ClasseQualquer : Form, new()
        {
            // Cria uma nova instância da classe genérica
            ClasseQualquer objetoDaClasseQualquer = new ClasseQualquer();
            Form openForm1 = FormJaAberto(typeof(ClasseQualquer));

            if (openForm1 != null)
            {
                openForm1.Focus();
            }
            else
            {
                objetoDaClasseQualquer.Show();
                if (fecharFormAtual)
                {
                    Close();
                }
            }
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
        private void btnMenu_Click(object sender, EventArgs e)
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
        private void TelaEstoqueInsumos_KeyDown(object sender, KeyEventArgs e)
        {
            //Responsável por fechar tela atual e abrir a anterior
            if (e.KeyData == Keys.Escape)
            {
                FecharPrograma();
            }
        }
        //Ao clicar na tela com o Menu aberto, fecha o menu
        private void TelaEstoqueInsumos_MouseClick(object sender, MouseEventArgs e)
        {
            if (vezesBtnMenuClicado % 2 != 0)
            {
                OcultarMenu();
            }
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            AbrirForm<TelaEstoqueNovoCadastro>(false);
            btnNovoCadastro.Enabled = false;
        }

        private void btnNovoCadastro_MouseUp(object sender, MouseEventArgs e)
        {
            btnNovoCadastro.Enabled = true;

        }
        string nomeFuncionario;
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        //-------------------------------------- BANCO DE DADOS --------------------------------------
        //----------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------
        private string SqlStringDeConexao = @"Data Source=CYBERLOGRA\SQLSERVER2022;Initial Catalog=DBMorangolandia;Integrated Security=True";
        private string codigo, nome, quantidade, valor, categoria;  // Variáveis para armazenar os dados do banco

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo de código foi preenchido
            if (string.IsNullOrWhiteSpace(textBoxCodigo.Text))
            {
                // Se o campo estiver vazio, exibe uma mensagem e interrompe a execução
                MessageBox.Show("O campo de código é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai da função, não continua a execução
            }

            // Armazena o valor digitado no campo de código
            string codigo = textBoxCodigo.Text;
            string query = "";  // Variável que armazenará a consulta SQL a ser executada

            // Verifica se o tipo selecionado é Insumo ou Produto
            if (radioBtnInsumos.Checked)
            {
                // Se for Insumo, cria uma consulta para a tabela TBInsumos
                query = "SELECT [cod_insum], [nome_insum], [qtd_insum], [valor_insum], [cat_insum] " +
                        "FROM [DBMorangolandia].[dbo].[TBInsumos] " +
                        "WHERE [cod_insum] = @codigo"; // Busca o insumo pelo código
            }
            else if (radioBtnProdutos.Checked)
            {
                // Se for Produto, cria uma consulta para a tabela TBProdutos
                query = "SELECT [cod_prod], [nome_prod], [qtd_prod], [valor_prod] " +
                        "FROM [DBMorangolandia].[dbo].[TBProdutos] " +
                        "WHERE [cod_prod] = @codigo"; // Busca o produto pelo código
            }
            else
            {
                // Caso nenhum RadioButton tenha sido selecionado (nem Insumo nem Produto)
                MessageBox.Show("Selecione Insumos ou Produtos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Interrompe a execução caso nenhum tipo seja selecionado
            }

            // Verifica se a opção de ordenação alfabética foi marcada
            if (radioBtnSim.Checked)
            {
                // Ordena alfabeticamente pelo nome (se Insumo ou Produto)
                if (radioBtnInsumos.Checked)
                {
                    query += " ORDER BY [nome_insum]"; // Ordena os insumos pelo nome
                }
                else if (radioBtnProdutos.Checked)
                {
                    query += " ORDER BY [nome_prod]"; // Ordena os produtos pelo nome
                }
            }

            // Executa a consulta e armazena o resultado
            DataTable resultados = ConsultarDados(SqlStringDeConexao, query, codigo);

            // Limpa as labels antes de exibir novos resultados
            LimparResultados();

            // Verifica se a consulta retornou algum resultado
            if (resultados.Rows.Count > 0)
            {
                // Chama o método para exibir os resultados no painel
                CriarComponentesDinamicos(resultados);
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método que executa a consulta no banco de dados com base na string de consulta e código
        private DataTable ConsultarDados(string connectionString, string query, string codigo)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar o banco de dados. Erro: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        private void radioBtnInsumos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarTodosOsDados();  // Chama o método para carregar todos os dados de insumos ou produtos
            LimparResultados();
        }

        private void radioBtnProdutos_CheckedChanged(object sender, EventArgs e)
        {
            CarregarTodosOsDados();  // Chama o método para carregar todos os dados de insumos ou produtos
            LimparResultados();
        }

        // Método para limpar os resultados anteriores
        private void LimparResultados()
        {
            panelResultado.Controls.Clear();  // Limpa o painel de resultados
        }

        // Método para criar os painéis dinâmicos para exibir os dados
        private void CriarComponentesDinamicos(DataTable resultados)
        {
            int yOffset = 0;  // Controle de posição vertical

            foreach (DataRow row in resultados.Rows)
            {
                // Criar o painel principal
                Panel panel = new Panel
                {
                    Size = new Size(920, 60),
                    BackColor = Color.LavenderBlush,
                    Location = new Point(200, yOffset),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Criar labels para as informações
                Label lblCodigo = new Label
                {
                    Text = $"Código: {row["cod_insum"] ?? row["cod_prod"]}",
                    Location = new Point(10, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true
                };

                Label lblNome = new Label
                {
                    Text = $"Nome: {row["nome_insum"] ?? row["nome_prod"]}",
                    Location = new Point(80, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label lblQuantidade = new Label
                {
                    Text = $"Quantidade: {row["qtd_insum"] ?? row["qtd_prod"]}",
                    Location = new Point(300, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label lblValor = new Label
                {
                    Text = $"Valor: R${row["valor_insum"] ?? row["valor_prod"]}",
                    Location = new Point(450, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                // Adiciona as labels ao painel
                panel.Controls.Add(lblCodigo);
                panel.Controls.Add(lblNome);
                panel.Controls.Add(lblQuantidade);
                panel.Controls.Add(lblValor);

                // Adiciona o painel ao painel principal
                panelResultado.Controls.Add(panel);

                // Incrementa a posição vertical para o próximo painel
                yOffset += 70;
            }

            // Ajusta a altura do painel principal após adicionar todos os painéis de dados
            panelResultado.AutoScroll = true;
            panelResultado.AutoScrollMinSize = new Size(0, yOffset);
        }

        // Novo método para carregar todos os dados
        private void CarregarTodosOsDados()
        {
            // Verifica se o tipo selecionado é Insumo ou Produto
            string query = "";

            if (radioBtnInsumos.Checked)
            {
                // Se for Insumo, cria uma consulta para a tabela TBInsumos
                query = "SELECT [cod_insum], [nome_insum], [qtd_insum], [valor_insum], [cat_insum] " +
                        "FROM [DBMorangolandia].[dbo].[TBInsumos]";
            }
            else if (radioBtnProdutos.Checked)
            {
                // Se for Produto, cria uma consulta para a tabela TBProdutos
                query = "SELECT [cod_prod], [nome_prod], [qtd_prod], [valor_prod] " +
                        "FROM [DBMorangolandia].[dbo].[TBProdutos]";
            }
            else
            {
                // Caso nenhum RadioButton tenha sido selecionado (nem Insumo nem Produto)
                MessageBox.Show("Selecione Insumos ou Produtos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Interrompe a execução caso nenhum tipo seja selecionado
            }

            // Executa a consulta e armazena o resultado
            DataTable resultados = ConsultarDados(SqlStringDeConexao, query, "");

            // Limpa as labels antes de exibir novos resultados
            LimparResultados();

            // Verifica se a consulta retornou algum resultado
            if (resultados.Rows.Count > 0)
            {
                // Chama o método para exibir os resultados no painel
                ExibirResultados(resultados);
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Novo método para exibir os resultados sem alterar os já existentes
        private void ExibirResultados(DataTable resultados)
        {
            int yOffset = 0;  // Controle de posição vertical

            foreach (DataRow row in resultados.Rows)
            {
                // Criar o painel principal
                Panel panel = new Panel
                {
                    Size = new Size(920, 60),
                    BackColor = Color.LavenderBlush,
                    Location = new Point(200, yOffset),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Criar labels para as informações
                Label lblCodigo = new Label
                {
                    Text = $"Código: {row["cod_insum"] ?? row["cod_prod"]}",
                    Location = new Point(10, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    AutoSize = true
                };

                Label lblNome = new Label
                {
                    Text = $"Nome: {row["nome_insum"] ?? row["nome_prod"]}",
                    Location = new Point(80, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label lblQuantidade = new Label
                {
                    Text = $"Quantidade: {row["qtd_insum"] ?? row["qtd_prod"]}",
                    Location = new Point(300, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                Label lblValor = new Label
                {
                    Text = $"Valor: R${row["valor_insum"] ?? row["valor_prod"]}",
                    Location = new Point(450, 15),
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                // Adiciona as labels ao painel
                panel.Controls.Add(lblCodigo);
                panel.Controls.Add(lblNome);
                panel.Controls.Add(lblQuantidade);
                panel.Controls.Add(lblValor);

                // Adiciona o painel ao painel principal
                panelResultado.Controls.Add(panel);

                // Incrementa a posição vertical para o próximo painel
                yOffset += 70;
            }

            // Ajusta a altura do painel principal após adicionar todos os painéis de dados
            panelResultado.AutoScroll = true;
            panelResultado.AutoScrollMinSize = new Size(0, yOffset);
        }
    }
}
