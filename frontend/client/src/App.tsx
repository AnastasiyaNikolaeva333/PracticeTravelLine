// fromText: "1 Polish zloty is",
//   toText: "0.99 Japanese yen",
//     dateText: "Fri, 05 Apr 2026 10:35 UTC"
//         }}
// infoCurrencies = {
//   [
//   { id: 1, value: "1", currency: "PLN" },
//   { id: 2, value: "0,99", currency: "JPY" }
//           currenciesData = {
//     [
//     {
//       id: 1,
//       title: "Polish zloty - PLN - zł",
//       description: "This is the official currency and legal tender of Poland. It is subdivided into 100 grosz-y (gr). It is the most traded currency in Central and Eastern Europe and ranks 21st most-traded in the foreign exchange market."
//     },
//     {
//       id: 2,
//       title: "Japanese yen - JPY - ¥",
//       description: "The yen is the official currency of Japan. It is the third-most traded currency in the foreign exchange market, after the United States dollar and the euro. It is also widely used as a third reserve currency after the US dollar and the euro."
//     }



import { MoreAboutCurrencys } from "./components/MoreAboutCurrencys/MoreAboutCurrencys";
import { CurrencyTransfer } from "./components/CurrencyTransfer/CurrencyTransfer";
import type { Currency } from "./models/Currency";

export default function App() {
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

  return (
    <div className="app">
      <CurrencyTransfer from={from} to={to} date={new Date()} />
      <MoreAboutCurrencys currenciesData={currenciesData} />
    </div>
  );
}