DROP TABLE IF EXISTS "People";
DROP TABLE IF EXISTS transaction;
DROP TABLE IF EXISTS transaction_type;
DROP TABLE IF EXISTS account;

CREATE TABLE account (
    id INT GENERATED ALWAYS AS IDENTITY,
    name VARCHAR NOT NULL,
    PRIMARY KEY(id)
);

INSERT INTO account (name)
VALUES
('checking'), ('credit'), ('savings');

CREATE TABLE transaction_type (
    id INT GENERATED ALWAYS AS IDENTITY,
    name VARCHAR NOT NULL,
    PRIMARY KEY(id)
);

INSERT INTO transaction_type (name)
VALUES
('groceries'), ('rent/utilities'), ('restaurants'), ('travel'), ('medical');

CREATE TABLE "transaction" (
    id INT GENERATED ALWAYS AS IDENTITY,
    description VARCHAR NOT NULL,
    amount DECIMAL NOT NULL,
    account_id INT,
    transaction_type_id INT,
    CONSTRAINT fk_account
        FOREIGN KEY(account_id) 
        REFERENCES account(id),
    CONSTRAINT fk_transaction_type
        FOREIGN KEY(transaction_type_id) 
        REFERENCES transaction_type(id)
);