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

  const handleAmountChange = (newAmount: number) => {
    setAmount(newAmount);
  };

  const from: CurrencyAllInfo = {
    value: amount,
    code: fromCurrency.code,
    description: fromCurrency.description ?? 'Нет описания',
    name: fromCurrency.name,
    symbol: fromCurrency.symbol
  };
  const to: CurrencyAllInfo = {
    value: amount,
    code: toCurrency.code,
    description: toCurrency.description ?? 'Нет описания',
    name: toCurrency.name,
    symbol: toCurrency.symbol
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
