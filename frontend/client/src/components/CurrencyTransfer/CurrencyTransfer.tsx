import { priceChanges } from '../../mocks/currencyMocks';
import type { CurrencyAllInfo } from '../../models/CurrencyInfo';
import { Header } from './Header/Header';
import { TableTranslation } from './TableTranslation/TableTranslation';

type CurrencyTransferCurrency = Pick<CurrencyAllInfo, `name` | `code` | `value`>;

type CurrencyTransferProps = {
  from: CurrencyTransferCurrency;
  to: CurrencyTransferCurrency;
  date: Date;
  onFromCurrencyChange: (currency: string) => void;
  onToCurrencyChange: (currency: string) => void;
  onAmountChange: (amount: number) => void;
  onSwap: () => void;
};

export const CurrencyTransfer = ({
  from,
  to,
  date,
  onFromCurrencyChange,
  onAmountChange,
  onSwap,
  onToCurrencyChange
}: CurrencyTransferProps) => {
  const rate = priceChanges[from.code]?.[to.code]?.price || 0;
  const amount = Math.round(from.value * rate * 100) / 100;
  const result = amount > 0 ? amount : 0;

  const updateTo: CurrencyTransferCurrency = {
    code: to.code,
    name: to.name,
    value: result
  };
  return (
    <>
      <Header from={from} to={updateTo} date={date} />
      <TableTranslation
        from={from}
        to={updateTo}
        onFromCurrencyChange={onFromCurrencyChange}
        onToCurrencyChange={onToCurrencyChange}
        onAmountChange={onAmountChange}
        onSwap={onSwap}
      />
    </>
  );
};
