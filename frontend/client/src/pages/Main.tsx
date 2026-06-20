import { CurrencyTransfer } from '../components/CurrencyTransfer/CurrencyTransfer';
import { MoreAboutCurrencies } from '../components/MoreAboutCurrencies/MoreAboutCurrencies';
import styles from './Main.module.scss';
import { useCurrencyConverter } from '../hooks/useCurrencyConverter';

export const Main = () => {
  const { from, to, handleAmountChange, handleFromCurrencyChange, handleSwap, handleToCurrencyChange } =
    useCurrencyConverter();

  const currenciesData = [from, to].map((currency) => ({
    code: currency.code,
    title: `${currency.name} - ${currency.code} - ${currency.symbol}`,
    description: currency.description
  }));

  const pairKey = `${currenciesData[0].code}/${currenciesData[1].code}`;

  return (
    <div className={styles.allContent}>
      <CurrencyTransfer
        from={from}
        to={to}
        date={new Date()}
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
