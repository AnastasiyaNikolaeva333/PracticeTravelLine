
import styles from './App.module.scss';
import { CurrencyTransfer } from './components/CurrencyTransfer/CurrencyTransfer';
import { MoreAboutCurrencies } from './components/MoreAboutCurrencies/MoreAboutCurrencies';
import type { Currency } from './models/Currency';

const from: Currency = {
  id: 1,
  value: 1,
  code: "PLN",
  name: "Polish zloty",
  description: "This is the official currency and legal tender of Poland. It is subdivided into 100 grosz-y (gr). It is the most traded currency in Central and Eastern Europe and ranks 21st most-traded in the foreign exchange market.",
  symbol: "zł",
};
const to: Currency = {
  id: 2,
  value: 0.99,
  code: "JPY",
  name: "Japanese yen",
  description: "The yen is the official currency of Japan. It is the third-most traded currency in the foreign exchange market, after the United States dollar and the euro. It is also widely used as a third reserve currency after the US dollar and the euro.",
  symbol: "¥",
};

const currenciesData = [from, to].map(currency => ({ id: currency.id, title: `${currency.name} - ${currency.code} - ${currency.symbol}`, description: currency.description }));


export const App = () => {
  return (
    <div className={styles.allContent}>
      <div className={styles.app}>
        <CurrencyTransfer from={from} to={to} date={new Date()} />
        <MoreAboutCurrencies currenciesData={currenciesData} />
      </div>
    </div>
  );
}