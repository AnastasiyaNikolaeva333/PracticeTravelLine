import styles from './CurrencyTransfer.module.scss'
import { Header } from './Header';
import { TableTranslation } from './TableTranslation';

export const CurrencyTransfer = () => {
    return (
        <div className={styles.container}>
            <Header />
            <TableTranslation />
        </div >
    );
}