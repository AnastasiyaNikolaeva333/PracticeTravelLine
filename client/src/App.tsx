import { MoreAboutCurrencys } from "./components/MoreAboutCurrencys/MoreAboutCurrencys";
import { CurrencyTransfer } from "./components/CurrencyTransfer/CurrencyTransfer";

export default function App() {
  return (
    <div className="app">
      <CurrencyTransfer/>
      <MoreAboutCurrencys />
    </div>
  );
}
