CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
    DECLARE @index INT = 1
    DECLARE @wordLength INT = LEN(@word)

    WHILE(@index <= @wordLength)
    BEGIN
        DECLARE @symbol VARCHAR(1) = SUBSTRING(@word, @index, 1)

        IF (CHARINDEX(@symbol, @setOfLetters, 1) = 0)
            RETURN 0

        SET @index += 1    
    END

    RETURN 1
END