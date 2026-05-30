import type { Currency } from '../../models/Currency';
import styles from './CurrencyTransfer.module.scss'
import { Header } from './Header/Header';
import { TableTranslation } from './TableTranslation/TableTranslation';

type CurrencyTransferCurrency = Pick<Currency, `name` | `code` | `value`>;

type CurrencyTransferProps = {
    from: CurrencyTransferCurrency;
    to: CurrencyTransferCurrency;
    date: Date;
}

export const CurrencyTransfer = ({ from, to, date }: CurrencyTransferProps) => {
    return (
        <div className={styles.container}>
            <Header
                from={from}
                to={to}
                date={date}
            />
            <TableTranslation from={from} to={to} />
        </div>
    );
};