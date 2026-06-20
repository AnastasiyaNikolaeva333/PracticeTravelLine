import type { CurrencyAllInfo } from '../../../models/CurrencyInfo';
import { CurrencyInput } from './CurrencyInput/CurrencyInput';
import { SwapButton } from './CurrencyInput/SwapButton/SwapButton';
import styles from './TableTranslation.module.scss';

type TableTranslationCurrency = Pick<CurrencyAllInfo, `code` | `value`>;

type TableTranslationProps = {
  from: TableTranslationCurrency;
  to: TableTranslationCurrency;
  onFromCurrencyChange: (currency: string) => void;
  onToCurrencyChange: (currency: string) => void;
  onAmountChange: (amount: number) => void;
  onSwap: () => void;
};

export const TableTranslation = ({
  from,
  to,
  onAmountChange,
  onFromCurrencyChange,
  onSwap,
  onToCurrencyChange
}: TableTranslationProps) => {
  return (
    <div className={styles.tableTranslation}>
      <CurrencyInput
        value={from.value}
        currency={from.code}
        onCurrencyChange={onFromCurrencyChange}
        onAmountChange={onAmountChange}
        isEditable={true}
      />
      <SwapButton onSwap={onSwap} />
      <CurrencyInput
        value={to.value}
        currency={to.code}
        onCurrencyChange={onToCurrencyChange}
        onAmountChange={onAmountChange}
        isEditable={false}
      />
    </div>
  );
};
