import type { Currency } from '../../../models/Currency';
import { CurrencyInput } from './CurrencyInput';
import styles from './TableTranslation.module.scss'

type TableTranslationCurrency = Pick<Currency, `code` | `value`>;

type TableTranslationProps = {
    from: TableTranslationCurrency;
    to: TableTranslationCurrency;
}

export const TableTranslation = ({ from, to }: TableTranslationProps) => {
    return (
        <div className={styles.tableTranslation}>
            <CurrencyInput
                value={from.value.toString()}
                currency={from.code}
            />
            <CurrencyInput
                value={to.value.toString()}
                currency={to.code}
            />
        </div>
    );
};