CREATE DATABASE DBMorangolandia; 
USE DBMorangolandia;

CREATE TABLE TBLogin( 
id_login INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
usuario_log VARCHAR (30) UNIQUE, 
senha_log VARCHAR (50),
status_login BIT,
NumeroSerie (VARCHAR(50)
); 

CREATE TABLE TBDepartamento( 
id_depto INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
nome_depto VARCHAR (30) UNIQUE, 
desc_depto VARCHAR (100) 
); 

CREATE TABLE TBFuncionario( 
id_func INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_depto INT, 
fk_login INT, 
cod_func INT UNIQUE, 
nome_func VARCHAR (50), 
email_func VARCHAR (50) UNIQUE, 
telefone_func INT UNIQUE, 
cargo_func VARCHAR (30), 
status_func VARCHAR (10),  
obs_func VARCHAR (100), 
anexo_func NVARCHAR(MAX),
cpf_func VARCHAR(11) UNIQUE,
CONSTRAINT fk_depto_func FOREIGN KEY (fk_depto) REFERENCES 
TBDepartamento(id_depto) 
CONSTRAINT fk_login_func FOREIGN KEY (fk_login) REFERENCES 
TBLogin(id_login) 
);  

CREATE TABLE TBFornecedor( 
id_forn INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
cnpj_forn VARCHAR (14) UNIQUE, 
razao_social VARCHAR (50), 
nome_fant VARCHAR (50), 
email_forn VARCHAR (25) UNIQUE, 
telefone_forn INT UNIQUE, 
obs_forn VARCHAR (100), 
anexo_forn NVARCHAR(MAX), 
); 

CREATE TABLE TBEndereco( 
id_end INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_func INT, 
fk_forn INT, 
endereco VARCHAR (50), 
cep INT, 
num INT, 
complemento VARCHAR (50), 
bairro VARCHAR (50), 
cidade VARCHAR (50), 
uf VARCHAR (2), 
CONSTRAINT fk_end_func FOREIGN KEY (fk_func) REFERENCES 
TBFuncionario(id_func), 
CONSTRAINT fk_end_forn FOREIGN KEY (fk_forn) REFERENCES 
TBFornecedor(id_forn), 
UNIQUE (fk_func, fk_forn) 
); 

CREATE TABLE TBCompras( 
id_compras INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_forn INT, 
fk_insum INT, 
nf VARCHAR(MAX), 
anexo_nf NVARCHAR(MAX), 
dt_emissao DATE, 
cod_compra INT UNIQUE, 
nome_produto VARCHAR (100), 
qtd_produto INT, 
valor_unit FLOAT, 
obs_compras VARCHAR (100), 
status_compras VARCHAR (10), 
CONSTRAINT fk_compras_forn FOREIGN KEY (fk_forn) REFERENCES 
TBFornecedor(id_forn), 
CONSTRAINT fk_compras_insum FOREIGN KEY (fk_insum) REFERENCES 
TBInsumos(id_insum) 
); 

CREATE TABLE TBProdutos( 
id_prod INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
cod_prod INT UNIQUE, 
nome_prod VARCHAR (50), 
cat_prod VARCHAR (30), 
qtd_prod INT, 
valor_prod FLOAT, 
dt_prod DATE 
); 

CREATE TABLE TBInsumos( 
id_insum INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
cod_insum INT UNIQUE, 
nome_insum VARCHAR (50), 
cat_insum VARCHAR (30), 
qtd_insum INT, 
valor_insum FLOAT, 
dt_insum DATE, 
);

CREATE TABLE TBCompras_Inumos(
id_compras_insum INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
fk_compras INT, 
cod_produto INT UNIQUE,
nome_produto VARCHAR(30),
qtd_produto INT,
valor_unit FLOAT
CONSTRAINT fk_insum_compras FOREIGN KEY 
(fk_compras) REFERENCES TBCompras (id_compras)
);

CREATE TABLE TBEstoque( 
id_estoq INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_prod INT, 
fk_insum INT, 
dt_entra_estoq DATE, 
dt_sai_estoq DATE, 
CONSTRAINT fk_estoq_prod FOREIGN KEY (fk_prod) REFERENCES 
TBProdutos(id_prod), 
CONSTRAINT fk_estoq_insum FOREIGN KEY (fk_insum) REFERENCES 
TBInsumos(id_insum) 
);

CREATE TABLE TBOP ( 
id_op INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_estoq INT, 
cod_op INT UNIQUE, 
nome_prod_op VARCHAR (50), 
qtd_op INT, 
dt_op DATE, 
CONSTRAINT fk_estoq_op FOREIGN KEY (fk_estoq) REFERENCES 
TBEstoque(id_estoq) 
); 
 
CREATE TABLE TBVendas( 
id_vendas INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_prod INT, 
cod_vendas INT UNIQUE, 
nome_prod_ven VARCHAR (30), 
qtd_prod_ven INT, 
valor_unit_ven FLOAT, 
valor_total_ven FLOAT, 
CONSTRAINT fk_vendas_prod FOREIGN KEY (fk_prod) REFERENCES 
TBProdutos(id_prod) 
); 

CREATE TABLE TBProducao( 
id_producao INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_op INT,
cod_prod INT,
nome_prod VARCHAR(50),
qtd_prod FLOAT,
status_producao INT,
CONSTRAINT fk_producao_op FOREIGN KEY (fk_op) REFERENCES TBOP 
(id_op) 
); 

CREATE TABLE TBPrateleiras( 
id_prat INT PRIMARY KEY IDENTITY (1,1) NOT NULL, 
fk_estoq INT, 
CONSTRAINT fk_prat_estoq FOREIGN KEY (fk_estoq) REFERENCES 
TBEstoque(id_estoq) 
);