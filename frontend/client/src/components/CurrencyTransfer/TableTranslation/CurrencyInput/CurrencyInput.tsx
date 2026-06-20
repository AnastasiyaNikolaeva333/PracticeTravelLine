import { CurrencySelect } from './CurrencySelect/CurrencySelect';
import styles from './CurrencyInput.module.scss';
import line from '../../../../assets/line.png';
import { Input } from './Input/Input';

type CurrencyInputProps = {
  value: number;
  currency: string;
  onCurrencyChange: (newCurrency: string) => void;
  onAmountChange: (amount: number) => void;
  isEditable?: boolean;
};

export const CurrencyInput = ({
  value,
  currency,
  onCurrencyChange,
  onAmountChange,
  isEditable = false
}: CurrencyInputProps) => {
  return (
    <div className={styles.rowTable} data-testid={'currency'}>
      <div className={styles.input}>
        {isEditable ? (
          <Input value={value} onAmountChange={onAmountChange} />
        ) : (
          <span data-testid={'currency-value'}>{value}</span>
        )}
      </div>
      <img src={line} alt="Линия" />
      <CurrencySelect selectedCurrency={currency} onSelect={onCurrencyChange} />
    </div>
  );
};
