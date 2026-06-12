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
  testId?: string;
};

export const CurrencyInput = ({
  value,
  currency,
  onCurrencyChange,
  onAmountChange,
  isEditable = false,
  testId
}: CurrencyInputProps) => {
  return (
    <div className={styles.rowTable} data-testid={testId}>
      <div className={styles.input}>
        {isEditable ? (
          <Input value={value} onAmountChange={onAmountChange} testId={`${testId}-input`} />
        ) : (
          <span data-testid={`${testId}-value`}>{value}</span>
        )}
      </div>
      <img src={line} alt="Линия" />
      <CurrencySelect selectedCurrency={currency} onSelect={onCurrencyChange} testId={`${testId}-select`} />
    </div>
  );
};
