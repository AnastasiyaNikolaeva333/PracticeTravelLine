import styles from './TableTranslation.module.scss'
import { CurrencyInput } from './CurrencyInput';

type TableTranslationProps = {
    currencies: Array<{
        id: number;
        value: string;
        currency: string;
    }>;
}

export const TableTranslation = (props: TableTranslationProps) => {
    return (
        <div className={styles.tableTranslation}>
            {props.currencies.map((row) => (
                <CurrencyInput
                    key={row.id}
                    value={row.value}
                    currency={row.currency}
                />
            ))}
        </div>
    );
};