import styles from './TableTranslation.module.scss'
import line from '../../assets/Line.png'
import polygon from '../../assets/Polygon.png'

export const TableTranslation = () => {
    const currencyRows = [
        {
            id: 1,
            value: "1",
            currency: "PLN",
        },
        {
            id: 2,
            value: "0,99",
            currency: "JPY",
        },
    ];
    return (
        <div className={styles.tableTranslation}>
            {currencyRows.map((row) => (
                <div key={row.id} className={styles.rowTable}>
                    <div className={styles.data}>
                        <span >{row.value}</span>
                        <img src={line} alt="Линия" />
                        <span >{row.currency}</span>
                    </div>
                    <button className={styles.arrow}>
                        <img src={polygon} alt="Стрелка" />
                    </button>
                </div>
            ))}
        </div>
    );
}