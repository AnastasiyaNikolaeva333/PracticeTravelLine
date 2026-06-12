import { useCallback, useState } from 'react';
import { currencies } from '../mocks/currencyMocks';
import type { CurrencyAllInfo } from '../models/CurrencyInfo';

export const useCurrencyConverter = () => {
  const [fromCurrency, setFromCurrency] = useState(currencies[0]);
  const [toCurrency, setToCurrency] = useState(currencies[1]);
  const [amount, setAmount] = useState(1);

  const handleFromCurrencyChange = useCallback(
    (newCurrency: string) => {
      if (newCurrency === toCurrency.code) {
        setToCurrency(fromCurrency);
      }
      const index = currencies.findIndex((i) => i.code === newCurrency);
      setFromCurrency(currencies[index]);
    },
    [fromCurrency, toCurrency]
  );

  const handleToCurrencyChange = useCallback(
    (newCurrency: string) => {
      const index = currencies.findIndex((i) => i.code === newCurrency);
      if (newCurrency === fromCurrency.code) {
        setFromCurrency(toCurrency);
      }
      setToCurrency(currencies[index]);
    },
    [toCurrency, fromCurrency]
  );

  const handleSwap = useCallback(() => {
    setFromCurrency(toCurrency);
    setToCurrency(fromCurrency);
  }, [fromCurrency, toCurrency]);

  const handleAmountChange = useCallback((newAmount: number) => {
    setAmount(newAmount);
  }, []);

  const from: CurrencyAllInfo = {
    value: amount,
    code: fromCurrency.code,
    description: currencies[0].description ?? 'Нет описания',
    name: currencies[0].name,
    symbol: currencies[0].symbol
  };
  const to: CurrencyAllInfo = {
    value: amount,
    code: toCurrency.code,
    description: currencies[1].description ?? 'Нет описания',
    name: currencies[1].name,
    symbol: currencies[1].symbol
  };

  return {
    from,
    to,
    handleAmountChange,
    handleFromCurrencyChange,
    handleSwap,
    handleToCurrencyChange
  };
};
