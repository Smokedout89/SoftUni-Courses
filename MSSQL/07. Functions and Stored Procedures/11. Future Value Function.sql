CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yir FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
    DECLARE @result DECIMAL(18,4)
    SET @result = @sum * (POWER((1 + @yir), @years))

    RETURN @result
END