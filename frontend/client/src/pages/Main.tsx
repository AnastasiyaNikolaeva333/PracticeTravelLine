import { MoreAboutCurrencies } from '../components/MoreAboutCurrencies/MoreAboutCurrencies';
import styles from './Main.module.scss';
import { useCurrencyConverter } from '../hooks/useCurrencyConverter';
import { priceChanges } from '../mocks/currencyMocks';
import { Header } from '../components/CurrencyTransfer/Header/Header';
import { TableTranslation } from '../components/CurrencyTransfer/TableTranslation/TableTranslation';
import type { CurrencyTransferCurrency } from '../models/CurrencyInfo';

export const Main = () => {
  const { from, to, handleAmountChange, handleFromCurrencyChange, handleSwap, handleToCurrencyChange } =
    useCurrencyConverter();

  const currenciesData = [from, to].map((currency) => ({
    code: currency.code,
    title: `${currency.name} - ${currency.code} - ${currency.symbol}`,
    description: currency.description
  }));

  const rate = priceChanges[from.code]?.[to.code]?.price || 0;
  const amount = Math.round(from.value * rate * 100) / 100;
  const result = amount > 0 ? amount : 0;

  const updateTo: CurrencyTransferCurrency = {
    code: to.code,
    name: to.name,
    value: result
  };
  const pairKey = `${currenciesData[0].code}/${currenciesData[1].code}`;

  return (
    <div className={styles.allContent}>
      <Header from={from} to={updateTo} date={new Date()} />
      <TableTranslation
        from={from}
        to={updateTo}
        onFromCurrencyChange={handleFromCurrencyChange}
        onToCurrencyChange={handleToCurrencyChange}
        onAmountChange={handleAmountChange}
        onSwap={handleSwap}
      />
      <MoreAboutCurrencies key={pairKey} currenciesData={currenciesData} />
    </div>
    //key полного перерендера кнопки. то есть внутри isOpen(станет false). если бы не было}
    // //Key при изменеиии валют описание бы просто перерендорилось с сохранение открытого окна с описанием
  );
};
